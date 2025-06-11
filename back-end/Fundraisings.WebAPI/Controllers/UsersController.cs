using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Contracts;
using WebApp.Contracts.Users;
using WebApp.Validators;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;
    private readonly IPasswordHasher _passwordHasher;
    public UsersController(IUsersService usersService, IPasswordHasher passwordHasher)
    {
        _usersService = usersService;
        _passwordHasher = passwordHasher;
    }

    [Route("/create")]
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] UserCreateRequest request)
    {
        var validator = new UserCreateRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Something went wrong", validationResult.ToDictionary());
        }

        if (await _usersService.CheckEmail(request.Email))
        {
            throw new BadRequestException("Користувач з таким email вже існує");
        }
        var passwordHash = _passwordHasher.Hash(request.Password);
        var (user, error) = Fundraisings.Domain.Models.User.Create(
            Guid.NewGuid(), request.Email, passwordHash, request.Role, request.Status, request.Name,
            request.Surname, DateTime.UtcNow);
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var userId = await _usersService.CreateAsync(user);

        return Ok(userId);
    }
    [HttpPatch("status")]
    public async Task<IActionResult> UpdateStatus([FromBody] UserStatusUpdateRequest request)
    {
        // перевірка прав (адмін чи ін.)
        // валідація
        await _usersService.UpdateStatusAsync(request.UserId, request.NewStatus);
        return NoContent();
    }
    
    [HttpPatch("profile")]
    public async Task<IActionResult> UpdateProfile([FromBody] UserProfileUpdateRequest request)
    {
        // валідація
        await _usersService.UpdateProfileAsync(request.UserId, request.Description, request.ProfilePictureUrl);
        return NoContent();
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Login([FromBody] UserLoginRequest request)
    {
        var validator = new UserLoginRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Something went wrong", validationResult.ToDictionary());
        }
        
        var passwordHash = _passwordHasher.Hash(request.Password);
        User? user = await _usersService.GetByEmail(request.Email);
        if (user is null)
        {
            throw new Exception("The user was not found");
        }

        bool verified = _passwordHasher.Verify(request.Password, user.PasswordHash);
        if (!verified)
        {
            throw new Exception("The password is incorrect");
        }
        
        
        var userId = user.Id;
        return Ok(userId);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<UserResponse>>> GetAll()
    {
        var users = await _usersService.GetAllUsers();
        var response = users.Select(u => new UserResponse(u.Id, u.Email, u.PasswordHash, u.Role, 
            u.Status, u.Name, u.Surname, u.Description, u.ProfilePictureUrl));

        return Ok(response);
    }
}
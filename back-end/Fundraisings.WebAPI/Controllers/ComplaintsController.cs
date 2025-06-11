using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using WebApp.Contracts;
using WebApp.Contracts.Complaints;
using WebApp.Validators;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComplaintsController : ControllerBase
{
    private readonly IComplaintsService _complaintsService;
    
    public ComplaintsController(IComplaintsService complaintsService)
    {
        _complaintsService = complaintsService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] ComplaintCreateRequest request)
    {
        var validator = new ComplaintCreateRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        Console.WriteLine(validationResult);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Something went wrong", validationResult.ToDictionary());
        }

        var (complaint, error) = Complaint.Create(
            Guid.NewGuid(), request.UserId, request.FundraisingId, request.Description, "Open", DateTime.UtcNow);
    if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var complaintId = await _complaintsService.CreateAsync(complaint);

        return Ok(complaintId);
    }
}
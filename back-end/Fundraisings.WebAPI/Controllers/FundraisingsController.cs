using System.Diagnostics.Eventing.Reader;
using Fundraisings.Application.Services;
using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Contracts;
using WebApp.Validators;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FundraisingsController : ControllerBase
{
    private readonly IFundraisingsService _fundraisingService;
    private readonly IEquipmentsService _equipmentService;

    public FundraisingsController(IFundraisingsService fundraisingService, IEquipmentsService equipmentsService)
    {
        _fundraisingService = fundraisingService;
        _equipmentService = equipmentsService;
    }

    [Route("fundraising/create")]
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] FundraisingCreateRequest request)
    {
        var validator = new FundraisingCreateRequestValidator();
        var validationResult = await validator.ValidateAsync(request);
        Console.WriteLine(validationResult);
        if (!validationResult.IsValid)
        {
            throw new BadRequestException("Something went wrong", validationResult.ToDictionary());
        }

        var (fundraising, error) = Fundraising.Create(
            Guid.NewGuid(), request.Title, request.Description, 0, request.GoalAmount, request.VolunteerId,
            request.DirectionId, request.EquipmentId, request.DonationUrl, request.ImageUrl, 1,
            request.Deadline, "Open", DateTime.UtcNow);
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var fundraisingId = await _fundraisingService.CreateAsync(fundraising);

        return Ok(fundraisingId);
    }

    [Route("fundraising/details/{id}")]
    [HttpGet]
    public async Task<ActionResult<List<FundraisingResponse>>> GetOne(
        Guid id)
    {
        var fundraising = await _fundraisingService.GetOne(id);
        var response = new FundraisingResponse(fundraising.Id, fundraising.Title, fundraising.Description,
            fundraising.CurrentAmount, fundraising.GoalAmount, fundraising.VolunteerId,
            fundraising.DirectionId, fundraising.Direction.DirectionName, fundraising.EquipmentId,
            fundraising.Equipment.EquipmentType, fundraising.DonationUrl, fundraising.ImageUrl,
            fundraising.Value, fundraising.Deadline, fundraising.Status, fundraising.CreatedAt);
        return Ok(response);
    }

    [Route("fundraising/all")]
    [HttpGet]
    public async Task<ActionResult<List<FundraisingResponse>>> GetFiltered(
        [FromQuery] FundraisingsFilterRequest request)
    {
        var fundraisings = await _fundraisingService.GetByFilter(request.Search, request.DirectionId,
            request.EquipmentId, request.PageNumber, request.PageSize);
        var response = fundraisings.Select(f =>
            new FundraisingResponse(f.Id, f.Title, f.Description,
                f.CurrentAmount, f.GoalAmount, f.VolunteerId,
                f.DirectionId, f.Direction.DirectionName, f.EquipmentId, f.Equipment.EquipmentType, f.DonationUrl,
                f.ImageUrl, f.Value, f.Deadline, f.Status, f.CreatedAt));
        return Ok(response);
    }
}
using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using WebApp.Contracts.Directions;
using WebApp.Contracts.Equipments;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EquipmentsController : ControllerBase
{
    private readonly IEquipmentsService _equipmentsService;

    public EquipmentsController(IEquipmentsService equipmentsService)
    {
        _equipmentsService = equipmentsService;
    }
    [Route("equipment/add-equipment")]
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] EquipmentCreateRequest request)
    {
        var (equipment, error) = Equipment.Create(Guid.NewGuid(), request.EquipmentType, request.Weight);
        if (!string.IsNullOrEmpty(error))
        {
            return BadRequest(error);
        }

        var equipmentId = await _equipmentsService.CreateAsync(equipment);
        return Ok(equipmentId);
    }
    [Route("/equipments/all")]
    [HttpGet]
    public async Task<ActionResult<List<EquipmentResponse>>> GetAll()
    {
        var equipments = await _equipmentsService.GetAllEquipments();
        var response = equipments.Select(e => new EquipmentResponse(e.Id, e.EquipmentType));
        return Ok(response);
    }
}
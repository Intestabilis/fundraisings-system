using Fundraisings.Domain.Abstractions;
using Fundraisings.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using WebApp.Contracts.Directions;

namespace WebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DirectionsController : ControllerBase
{
    private readonly IDirectionsService _directionsService;

    public DirectionsController(IDirectionsService directionsService)
    {
        _directionsService = directionsService;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] DirectionCreateRequest request)
    {
        if (request.Coordinates.Count < 3)
        {
            return BadRequest("At least 3 coordinates are required to form a polygon.");
        }

        var geometryFactory = new GeometryFactory(new PrecisionModel(), 4326);
        var ntsCoords = request.Coordinates
            .Select(c => new Coordinate(c.Longitude, c.Latitude))
            .ToList();
        if (!ntsCoords.First().Equals2D(ntsCoords.Last()))
            ntsCoords.Add(ntsCoords.First());
        var linearRing = geometryFactory.CreateLinearRing(ntsCoords.ToArray());
        var polygon = geometryFactory.CreatePolygon(linearRing);
        var (direction, error) = Direction.Create(Guid.NewGuid(), request.DirectionName, polygon, request.Weight);
        var directionId = await _directionsService.CreateAsync(direction);
        return Ok(directionId);
    }
    
    [HttpGet]
    public async Task<ActionResult<List<AllDirectionsResponse>>> GetAll()
    {
        var directions = await _directionsService.GetAllDirections();
        var response = directions.Select(d => new AllDirectionsResponse(d.Id, d.DirectionName));
        
        return Ok(response);
    }
}
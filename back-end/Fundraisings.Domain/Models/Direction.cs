using NetTopologySuite.Geometries;

namespace Fundraisings.Domain.Models;

public class Direction
{
    Direction (Guid id, string directionName, Polygon geometry, decimal weight)
    {
        Id = id;
        DirectionName = directionName;
        Geometry = geometry;
        Weight = weight;
    }
    
    public Guid Id { get; set; }
    public string DirectionName { get; set; } = null!;
    public Polygon Geometry { get; set; } = null!;
    public decimal Weight { get; set; }
    
    public static (Direction? Direction, string Error) Create(Guid id, string directionName, Polygon geometry, decimal weight)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(directionName))
            errors.Add("Direction name is required.");

        if (directionName?.Length > 100)
            errors.Add("Direction name must be fewer than 100 characters.");

        if (geometry == null)
            errors.Add("Geometry is required.");
        else if (geometry.IsEmpty)
            errors.Add("Geometry cannot be empty.");

        if (weight <= 0)
            errors.Add("Weight must be greater than zero.");

        if (errors.Any())
            return (null, string.Join("; ", errors));

        var direction = new Direction(id, directionName, geometry, weight);
        return (direction, string.Empty);
    }
}
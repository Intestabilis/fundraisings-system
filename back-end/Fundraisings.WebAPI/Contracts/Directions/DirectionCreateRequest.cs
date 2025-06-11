namespace WebApp.Contracts.Directions;

public record CoordinateDto(double Latitude, double Longitude);

public record DirectionCreateRequest(
    string DirectionName,
    List<CoordinateDto> Coordinates,
    decimal Weight
    );
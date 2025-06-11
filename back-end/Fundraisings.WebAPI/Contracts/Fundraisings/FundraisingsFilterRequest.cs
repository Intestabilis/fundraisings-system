namespace WebApp.Contracts;

public record FundraisingsFilterRequest(
    string? Search,
    Guid? DirectionId = null,
    Guid? EquipmentId = null,
    int PageNumber = 1,
    int PageSize = 20
);
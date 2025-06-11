namespace WebApp.Contracts;

public record FundraisingResponse(
    Guid Id,
    string Title,
    string Description,
    decimal CurrentAmount,
    decimal GoalAmount,
    Guid VolunteerId,
    Guid DirectionId,
    string DirectionName,
    Guid EquipmentId,
    string EquipmentType,
    string DonationUrl,
    string? ImageUrl,
    decimal Value,
    DateTime? Deadline,
    string Status,
    DateTime CreatedAt
);
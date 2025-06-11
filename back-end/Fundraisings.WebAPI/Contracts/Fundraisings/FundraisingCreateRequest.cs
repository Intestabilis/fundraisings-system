namespace WebApp.Contracts;

public record FundraisingCreateRequest(
    string Title,
    string Description,
    decimal GoalAmount,
    Guid VolunteerId,
    Guid DirectionId,
    Guid EquipmentId,
    string DonationUrl,
    string? ImageUrl,
    DateTime? Deadline
);
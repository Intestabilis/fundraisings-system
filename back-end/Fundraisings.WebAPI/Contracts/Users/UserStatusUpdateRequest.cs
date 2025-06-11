namespace WebApp.Contracts.Users;

public record UserStatusUpdateRequest(
    Guid UserId,
    string NewStatus
);
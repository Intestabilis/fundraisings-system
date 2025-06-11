namespace WebApp.Contracts.Users;

public record UserProfileUpdateRequest(
    Guid UserId,
    string? Description,
    string? ProfilePictureUrl
);
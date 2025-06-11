namespace WebApp.Contracts.Users;

public record UserResponse(
    Guid Id,
    string Email,
    string PasswordHash,
    string Role,
    string Status,
    string Name,
    string Surname,
    string? Description,
    string? ProfilePictureUrl
    );
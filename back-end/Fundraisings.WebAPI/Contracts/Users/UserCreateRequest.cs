namespace WebApp.Contracts.Users;

public record UserCreateRequest(
    string Email,
    string Password,
    string Role,
    string Status,
    string Name,
    string Surname
    // string? Description,
    // string? ProfilePictureUrl,
);
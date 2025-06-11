namespace WebApp.Contracts.Users;

public record UserViewResponse(
    Guid Id,
    string Name,
    string Surname
);
namespace WebApp.Contracts.Users;

public record UserLoginRequest(
    string Email,
    string Password
);
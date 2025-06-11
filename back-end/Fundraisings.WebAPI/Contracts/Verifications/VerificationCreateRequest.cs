namespace WebApp.Contracts.Verifications;

public record VerificationCreateRequest(
    Guid UserId,
    string Description,
    string Status,
    DateTime CreatedAt
);
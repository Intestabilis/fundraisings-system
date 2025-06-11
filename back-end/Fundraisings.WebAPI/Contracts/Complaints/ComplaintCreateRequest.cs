namespace WebApp.Contracts.Complaints;

public record ComplaintCreateRequest(
    Guid UserId,
    Guid FundraisingId,
    string Description
);
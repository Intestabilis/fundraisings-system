namespace WebApp.Contracts;

public record FundraisingChangeStatusRequest(
    Guid Id,
    string NewStatus
);
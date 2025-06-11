namespace WebApp.Contracts.Reports;

public record ReportCreateRequest(
    Guid FundraisingId,
    string Description,
    DateTime CreatedAt
);
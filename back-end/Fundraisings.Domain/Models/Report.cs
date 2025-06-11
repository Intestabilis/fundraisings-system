namespace Fundraisings.Domain.Models;

public class Report
{
    public Guid Id { get; set; }
    public Guid FundraisingId { get; set; }
    public string Description { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public Fundraising Fundraising { get; set; } = null!;
    public ICollection<ReportFile> Files { get; set; } = new List<ReportFile>();
    
    public static (Report? Report, string Error) Create(
        Guid id,
        Guid fundraisingId,
        string description,
        DateTime createdAt)
    {
        var errors = new List<string>();

        if (fundraisingId == Guid.Empty)
            errors.Add("FundraisingId is required.");

        if (string.IsNullOrWhiteSpace(description))
            errors.Add("Description is required.");

        if (description?.Length > 1000)
            errors.Add("Description must be fewer than 1000 characters.");

        if (createdAt == default)
            errors.Add("CreatedAt must be a valid date.");

        if (errors.Any())
            return (null, string.Join("; ", errors));

        var report = new Report
        {
            Id = id,
            FundraisingId = fundraisingId,
            Description = description,
            CreatedAt = createdAt
        };

        return (report, string.Empty);
    }
    
}
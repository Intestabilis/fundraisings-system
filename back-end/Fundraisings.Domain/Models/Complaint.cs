
namespace Fundraisings.Domain.Models;

public class Complaint
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid FundraisingId { get; set; }
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = null!;
    public Fundraising Fundraising { get; set; } = null!;
    public ICollection<ComplaintFile> Files { get; set; } = new List<ComplaintFile>();
    
    public static (Complaint? Complaint, string Error) Create(
        Guid id,
        Guid userId,
        Guid fundraisingId,
        string description,
        string status,
        DateTime createdAt)
    {
        var errors = new List<string>();

        if (userId == Guid.Empty)
            errors.Add("UserId is required.");

        if (fundraisingId == Guid.Empty)
            errors.Add("FundraisingId is required.");

        if (string.IsNullOrWhiteSpace(description))
            errors.Add("Description is required.");

        if (description?.Length > 1000)
            errors.Add("Description must be fewer than 1000 characters.");

        if (string.IsNullOrWhiteSpace(status))
            errors.Add("Status is required.");

        if (status?.Length > 50)
            errors.Add("Status must be fewer than 50 characters.");

        if (createdAt == default)
            errors.Add("CreatedAt must be a valid date.");

        if (errors.Any())
            return (null, string.Join("; ", errors));

        var complaint = new Complaint
        {
            Id = id,
            UserId = userId,
            FundraisingId = fundraisingId,
            Description = description,
            Status = status,
            CreatedAt = createdAt
        };

        return (complaint, string.Empty);
    }
    
}


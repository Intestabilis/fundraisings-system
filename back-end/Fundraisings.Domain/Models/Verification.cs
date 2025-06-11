
namespace Fundraisings.Domain.Models;

public class Verification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    
    public string Description { get; set; } = null!;
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public User User { get; set; } = null!;
    public ICollection<VerificationFile> Files { get; set; } = new List<VerificationFile>();
    
    public static (Verification? Verification, string Error) Create(
        Guid id,
        Guid userId,
        string description,
        string status,
        DateTime createdAt)
    {
        var errors = new List<string>();

        if (userId == Guid.Empty)
            errors.Add("UserId is required.");

        if (string.IsNullOrWhiteSpace(description))
            errors.Add("Description is required.");
        else if (description.Length > 1000)
            errors.Add("Description must be fewer than 1000 characters.");

        if (string.IsNullOrWhiteSpace(status))
            errors.Add("Status is required.");
        else if (status.Length > 50)
            errors.Add("Status must be fewer than 50 characters.");

        if (createdAt == default)
            errors.Add("CreatedAt must be a valid date.");

        if (errors.Any())
            return (null, string.Join("; ", errors));

        var verification = new Verification
        {
            Id = id,
            UserId = userId,
            Description = description,
            Status = status,
            CreatedAt = createdAt
        };

        return (verification, string.Empty);
    }
    
}
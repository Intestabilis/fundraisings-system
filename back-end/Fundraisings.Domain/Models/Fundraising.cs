namespace Fundraisings.Domain.Models;

public class Fundraising
{
    Fundraising(Guid id, string title, string description,
        decimal currentAmount, decimal goalAmount, Guid volunteerId, Guid directionId, Guid equipmentId,
        string donationUrl, string? imageUrl, decimal value, DateTime? deadline, string status, DateTime createdAt)
    {
        Id = id;
        Title = title;
        Description = description;
        CurrentAmount = currentAmount;
        GoalAmount = goalAmount;
        VolunteerId = volunteerId;
        DirectionId = directionId;
        EquipmentId = equipmentId;
        DonationUrl = donationUrl;
        ImageUrl = imageUrl;
        Value = value;
        Deadline = deadline;
        Status = status;
        CreatedAt = createdAt;
    }

    public Guid Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal CurrentAmount { get; set; }
    public decimal GoalAmount { get; set; }
    public Guid VolunteerId { get; set; }
    public Guid DirectionId { get; set; }
    public Guid EquipmentId { get; set; }
    public string DonationUrl { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public decimal Value { get; set; }
    public DateTime? Deadline { get; set; }
    public string Status { get; set; } = null!;
    public DateTime CreatedAt { get; set; }

    public User Volunteer { get; set; } = null!;
    public Direction Direction { get; set; } = null!;
    public Equipment Equipment { get; set; } = null!;
    public ICollection<Report> Reports { get; set; } = new List<Report>();
    public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();

    public static (Fundraising Fundraising, string Error) Create(Guid id, string title, string description,
        decimal currentAmount, decimal goalAmount, Guid volunteerId, Guid directionId, Guid equipmentId,
        string donationUrl, string imageUrl, decimal value, DateTime? deadline, string status, DateTime createdAt)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(title) || title.Length > 100)
            errors.Add("Title is required and must be fewer than 100 characters.");

        if (string.IsNullOrWhiteSpace(description) || description.Length > 600)
            errors.Add("Description is required and must be fewer than 600 characters.");

        if (goalAmount <= 0)
            errors.Add("Goal amount must be greater than zero.");

        if (volunteerId == Guid.Empty)
            errors.Add("VolunteerId is required.");

        if (directionId == Guid.Empty)
            errors.Add("DirectionId is required.");

        if (equipmentId == Guid.Empty)
            errors.Add("EquipmentId is required.");

        if (string.IsNullOrWhiteSpace(donationUrl) || !Uri.IsWellFormedUriString(donationUrl, UriKind.Absolute))
            errors.Add("DonationUrl must be a valid URL.");

        if (!string.IsNullOrWhiteSpace(imageUrl) && !Uri.IsWellFormedUriString(imageUrl, UriKind.Absolute))
            errors.Add("ImageUrl must be a valid URL if provided.");

        if (value < 0)
            errors.Add("Value cannot be negative.");

        if (deadline.HasValue && deadline.Value <= DateTime.UtcNow)
            errors.Add("Deadline must be in the future.");

        if (errors.Count > 0)
            return (null, string.Join("; ", errors));

        var fundraising = new Fundraising(
            id,
            title,
            description,
            currentAmount,
            goalAmount,
            volunteerId,
            directionId,
            equipmentId,
            donationUrl,
            imageUrl,
            value,
            deadline,
            status,
            createdAt
        );

        return (fundraising, string.Empty);
    }
}
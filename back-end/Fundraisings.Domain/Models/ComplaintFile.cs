namespace Fundraisings.Domain.Models;

public class ComplaintFile
{
    public Guid Id { get; set; }
    public Guid ComplaintId { get; set; }
    public string FileUrl { get; set; } = null!;

    public Complaint Complaint { get; set; } = null!;
}
namespace Fundraisings.Domain.Models;

public class VerificationFile
{
    public Guid Id { get; set; }
    public Guid VerificationId { get; set; }
    public string FileUrl { get; set; } = null!;

    public Verification Verification { get; set; } = null!;
}

namespace Fundraisings.Domain.Models;

public class ReportFile
{
    public Guid Id { get; set; }
    public Guid ReportId { get; set; }
    public string FileUrl { get; set; } = null!;

    public Report Report { get; set; } = null!;
}
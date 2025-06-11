
namespace Fundraisings.Domain.Models;

public class User
{
    public Guid Id { get; set; }
 
    public string Email { get; set; } = null!;
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Surname { get; set; } = null!;
    public string? Description { get; set; }
    public string? ProfilePictureUrl { get; set; }
    public DateTime CreatedAt { get; set; }
  
    public ICollection<Fundraising> Fundraisings { get; set; } = new List<Fundraising>();
    public ICollection<Complaint> Complaints { get; set; } = new List<Complaint>();
    
    public static (User? User, string Error) Create(
    Guid id,
    string email,
    string passwordHash,
    string role,
    string status,
    string name,
    string surname,
    DateTime createdAt)
{
    var errors = new List<string>();

    if (string.IsNullOrWhiteSpace(email))
        errors.Add("Email is required.");
    else if (!IsValidEmail(email))
        errors.Add("Email is not valid.");

    if (string.IsNullOrWhiteSpace(passwordHash))
        errors.Add("PasswordHash is required.");

    if (string.IsNullOrWhiteSpace(role))
        errors.Add("Role is required.");

    if (string.IsNullOrWhiteSpace(status))
        errors.Add("Status is required.");

    if (string.IsNullOrWhiteSpace(name))
        errors.Add("Name is required.");
    else if (name.Length > 100)
        errors.Add("Name must be fewer than 100 characters.");

    if (string.IsNullOrWhiteSpace(surname))
        errors.Add("Surname is required.");
    else if (surname.Length > 100)
        errors.Add("Surname must be fewer than 100 characters.");

    if (createdAt == default)
        errors.Add("CreatedAt must be a valid date.");

    if (errors.Any())
        return (null, string.Join("; ", errors));

    var user = new User
    {
        Id = id,
        Email = email,
        PasswordHash = passwordHash,
        Role = role,
        Status = status,
        Name = name,
        Surname = surname,
        CreatedAt = createdAt
    };

    return (user, string.Empty);
}
    
private static bool IsValidEmail(string email)
{
    try
    {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
    }
    catch
    {
        return false;
    }
}
    
}
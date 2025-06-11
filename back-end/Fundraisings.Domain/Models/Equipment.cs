namespace Fundraisings.Domain.Models;

public class Equipment
{
    public Equipment(Guid id, string equipmentType, decimal weight)
    {
        Id = id;
        EquipmentType = equipmentType;
        Weight = weight;
    }
    public Guid Id { get; set; }
    public string EquipmentType { get; set; } = null!;
    public decimal Weight { get; set; }
    //
    // public ICollection<Fundraising> Fundraisings { get; set; } = new List<Fundraising>();
    
    public static (Equipment? Equipment, string Error) Create(Guid id, string equipmentType, decimal weight)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(equipmentType))
            errors.Add("Equipment type is required.");

        if (equipmentType?.Length > 100)
            errors.Add("Equipment type must be fewer than 100 characters.");

        if (weight <= 0)
            errors.Add("Weight must be greater than zero.");

        if (errors.Any())
            return (null, string.Join("; ", errors));

        var equipment = new Equipment(id, equipmentType, weight);
        return (equipment, string.Empty);
    }
    
}
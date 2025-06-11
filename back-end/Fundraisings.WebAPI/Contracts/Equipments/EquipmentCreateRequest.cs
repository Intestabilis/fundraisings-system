namespace WebApp.Contracts.Equipments;

public record EquipmentCreateRequest(
    string EquipmentType,
    decimal Weight
    );
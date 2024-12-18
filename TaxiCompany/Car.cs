namespace TaxiCompany.Domain;
/// <summary>
/// Класс Автомобиль хранит информацию об автомобиле
/// </summary>
public class Car
{
    /// <summary>
    /// Уникальный идентификатор автомобиля
    /// </summary>
    public required int CarId { get; set; }
    /// <summary>
    /// Цвет
    /// </summary>
    public required string Colour { get; set; }
    /// <summary>
    /// Модель
    /// </summary>
    public required string Model { get; set; }
    /// <summary>
    /// Гос. номер
    /// </summary>
    public required string StateNumber { get; set; }
    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    public required int AssignedDriverId { get; set; }
}

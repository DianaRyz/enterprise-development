using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiCompany.Domain.Models;
/// <summary>
/// Класс Автомобиль хранит информацию об автомобиле
/// </summary>
[Table("Cars")]
public class Car
{
    /// <summary>
    /// Уникальный идентификатор автомобиля
    /// </summary>
    [Key]
    [Column("CarID")]
    public required int CarId { get; set; }
    /// <summary>
    /// Цвет
    /// </summary>
    [Column("Colour")]
    [Required]
    [MaxLength(50)] 
    public required string Colour { get; set; }
    /// <summary>
    /// Модель
    /// </summary>
    [Column("Model")]
    [Required]
    [MaxLength(50)]
    public required string Model { get; set; }
    /// <summary>
    /// Гос. номер
    /// </summary>
    [Column("StateNumber")]
    [Required]
    [MaxLength(6)]
    public required string StateNumber { get; set; }
    /// <summary>
    /// Идентификатор водителя
    /// </summary>
    [ForeignKey("Driver")]
    [Column("DriverID")]
    public required int AssignedDriverId { get; set; }
}

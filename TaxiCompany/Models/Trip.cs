using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaxiCompany.Domain.Models;
/// <summary>
/// Класс Поездка хранит информацию о поездке
/// </summary>
[Table("Trips")]
public class Trip
{
    /// <summary>
    /// Уникальный идентификатор поездки
    /// </summary>
    [Key]
    [Column("TripID")]
    public required int TripId { get; set; }
    /// <summary>
    /// Пункт отправления
    /// </summary>
    [Column("Departure")]
    [Required]
    [MaxLength(100)]
    public required string Departure { get; set; }
    /// <summary>
    /// Пункт назначения
    /// </summary>
    [Column("Destination")]
    [Required]
    [MaxLength(100)]
    public required string Destination { get; set; }
    /// <summary>
    /// Дата поездки
    /// </summary>
    [Column("Date")]
    public required DateTime Date { get; set; }
    /// <summary>
    /// Время движения
    /// </summary>
    [Column("DrivingTime")]
    public TimeOnly DrivingTime { get; set; }
    /// <summary>
    /// Стоимость
    /// </summary>
    [Column("Cost")]
    [Required]
    public required decimal Cost { get; set; }
    /// <summary>
    /// Идентификатор клиента
    /// </summary>
    [ForeignKey("User")]
    [Column("UserID")]
    public required int AssignedUserId { get; set; }
    /// <summary>
    /// Идентификатор автомобиля
    /// </summary>
    [ForeignKey("Car")]
    [Column("CarID")]
    public required int AssignedCarId { get; set; }
}

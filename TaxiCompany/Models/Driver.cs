using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaxiCompany.Domain.Models;
/// <summary>
/// Класс Водитель хранит информацию о водителе
/// </summary>
[Table("Drivers")]
public class Driver
{
    /// <summary>
    /// Уникальный идентификатор водителя
    /// </summary>
    [Key]
    [Column("DriverID")]
    public required int DriverId { get; set; }
    /// <summary>
    /// ФИО
    /// </summary>
    [Column("FullName")]
    [Required]
    [MaxLength(100)]
    public required string FullName { get; set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    [Column("PhoneNumber")]
    [Required]
    [MaxLength(12)]
    public required string PhoneNumber { get; set; }
    /// <summary>
    /// Паспортные данные
    /// </summary>
    [Column("Passport")]
    [Required]
    [MaxLength(10)]
    public required string Passport { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    [Column("Address")]
    [Required]
    [MaxLength(100)]
    public required string Address { get; set; }
    /// <summary>
    /// Идентификатор закрепленного автомобиля
    /// </summary>
    [ForeignKey("Car")]
    [Column("CarID")]
    public required int AssignedCarId { get; set; }
}

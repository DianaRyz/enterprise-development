using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaxiCompany.Domain.Models;
/// <summary>
/// Класс Пользователь сервиса хранит информацию о пользователе
/// </summary>
[Table("Users")]
public class User
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    [Key]
    [Column("UserID")]
    public required int UserId { get; set; }
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
}

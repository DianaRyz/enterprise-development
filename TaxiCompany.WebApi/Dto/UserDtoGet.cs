namespace TaxiCompany.WebApi.Dto;
/// <summary>
/// DTO сущность User для Get запросов
/// </summary>
public class UserDtoGet
{
    /// <summary>
    /// Уникальный идентификатор пользователя
    /// </summary>
    public required int UserId { get; set; }
    /// <summary>
    /// ФИО
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    public required string PhoneNumber { get; set; }
}

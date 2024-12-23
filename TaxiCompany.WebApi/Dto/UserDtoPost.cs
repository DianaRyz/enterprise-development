namespace TaxiCompany.WebApi.Dto;
/// <summary>
/// DTO сущность User для Post запросов
/// </summary>
public class UserDtoPost
{
    /// <summary>
    /// ФИО
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    public required string PhoneNumber { get; set; }
}

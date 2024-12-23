﻿namespace TaxiCompany.WebApi.Dto;
/// <summary>
/// DTO сущность Driver для Post запросов
/// </summary>
public class DriverDtoPost
{
    /// <summary>
    /// ФИО
    /// </summary>
    public required string FullName { get; set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    public required string PhoneNumber { get; set; }
    /// <summary>
    /// Паспортные данные
    /// </summary>
    public required string Passport { get; set; }
    /// <summary>
    /// Адрес
    /// </summary>
    public required string Address { get; set; }
    /// <summary>
    /// Идентификатор закрепленного автомобиля
    /// </summary>
    public required int AssignedCarId { get; set; }
}

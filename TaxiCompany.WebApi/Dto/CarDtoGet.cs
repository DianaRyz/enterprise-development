﻿namespace TaxiCompany.WebApi.Dto;
/// <summary>
/// DTO сущность Car для Get запросов
/// </summary>
public class CarDtoGet
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
    public required int? AssignedDriverId { get; set; }
}

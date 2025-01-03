﻿namespace TaxiCompany.WebApi.Dto;
/// <summary>
/// DTO сущность Car для Post запросов
/// </summary>
public class CarDtoPost
{
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

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using TaxiCompany.Domain.Models;
using TaxiCompany.Domain.Repository;
using TaxiCompany.WebApi.Dto;
using TaxiCompany.WebApi.Services;

namespace TaxiCompany.WebApi.Controllers;

/// <summary>
/// Контроллер для управления автомобилями.
/// Предоставляет методы для получения, добавления, обновления и удаления автомобилей.
/// </summary>
/// <param name="service"></param>
[Route("api/[controller]")]
[ApiController]
public class CarController(IService service) : ControllerBase
{
    /// <summary>
    /// Получает список всех автомобилей
    /// </summary>
    /// <returns>Список автомобилей</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarDtoGet>>> Get()
    {
        var cars = await service.GetCars();
        return Ok(cars);
    }

    /// <summary>
    /// Получает автомобиль по уникальному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Автомобиль</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<CarDtoGet>> Get(int id)
    {
        var car = await service.GetCar(id);
        if (car == null) 
            return NotFound();
        return Ok(car);
    }

    /// <summary>
    /// Добавляет новый автомобиль
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Автомобиль</returns>
    [HttpPost]
    public async Task<ActionResult<CarDtoGet>> Post([FromBody] CarDtoPost value)
    {
        if (value == null)
            return BadRequest("Car data is null");

        var newId = await service.PostCar(value);
        var newCarDto = await service.GetCar(newId);
        return CreatedAtAction(nameof(Get), new { id = newId }, newCarDto);
    }

    /// <summary>
    /// Обновляет информацию о существующем автомобиле
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns>Обновленный автомобиль</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<CarDtoGet>> Put(int id, [FromBody] CarDtoPost value)
    {
        if (value == null)
            return BadRequest("Car data is null");

        var updatedCar = await service.PutCar(id, value);
        if (updatedCar == null)
            return NotFound($"Car with id {id} not found");

        return Ok(updatedCar);
    }

    /// <summary>
    /// Удаляет автомобиль по уникальному идентификатору
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var car = await service.DeleteCar(id);
        if (!car)
            return NotFound();
        return Ok();
    }
}

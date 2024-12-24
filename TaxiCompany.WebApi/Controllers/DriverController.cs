using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using TaxiCompany.Domain.Models;
using TaxiCompany.Domain.Repository;
using TaxiCompany.WebApi.Dto;
using TaxiCompany.WebApi.Services;

namespace TaxiCompany.WebApi.Controllers;

/// <summary>
/// Контроллер для управления водителями.
/// Предоставляет методы для получения, добавления, обновления и удаления водителей.
/// </summary>
/// <param name="service"></param>
[Route("api/[controller]")]
[ApiController]
public class DriverController(IService service) : ControllerBase
{
    /// <summary>
    /// Получает список всех водителей
    /// </summary>
    /// <returns>Список водителей</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DriverDtoGet>>> Get()
    {
        var drivers = await service.GetDrivers();
        return Ok(drivers);
    }

    /// <summary>
    /// Получает водителя по уникальному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Водитель</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<DriverDtoGet>> Get(int id)
    {
        var driver = await service.GetDriver(id);
        if (driver == null) 
            return NotFound();
        return Ok(driver);
    }

    /// <summary>
    /// Добавляет нового водителя
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Водитель</returns>
    [HttpPost]
    public async Task<ActionResult<DriverDtoGet>> Post([FromBody] DriverDtoPost value)
    {
        if (value == null)
            return BadRequest("Driver data is null");

        var newId = await service.PostDriver(value);
        var newDriverDto = await service.GetDriver(newId);
        return CreatedAtAction(nameof(Get), new { id = newId }, newDriverDto);
    }

    /// <summary>
    /// Обновляет информацию о существующем водителе
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns>Обновленный водитель</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<DriverDtoGet>> Put(int id, [FromBody] DriverDtoPost value)
    {
        if (value == null)
            return BadRequest("Driver data is null");

        var updatedDriver = await service.PutDriver(id, value);
        if (updatedDriver == null)
            return NotFound($"Driver with id {id} not found");

        return Ok(updatedDriver);
    }

    /// <summary>
    /// Удаление водителя
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var driver = await service.DeleteDriver(id);
        if (!driver)
            return NotFound();
        return Ok();
    }
}

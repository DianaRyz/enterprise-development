using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using TaxiCompany.Domain.Models;
using TaxiCompany.Domain.Repository;
using TaxiCompany.WebApi.Dto;
using TaxiCompany.WebApi.Services;

namespace TaxiCompany.WebApi.Controllers;

/// <summary>
/// Контроллер для управления поездками.
/// Предоставляет методы для получения, добавления, обновления и удаления поездки.
/// </summary>
/// <param name="service"></param>
[Route("api/[controller]")]
[ApiController]
public class TripController(IService service) : ControllerBase
{
    /// <summary>
    /// Получает список поездок
    /// </summary>
    /// <returns>Список поездок</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TripDtoGet>>> Get()
    {
        var trips = await service.GetTrips();
        return Ok(trips);
    }

    /// <summary>
    /// Получает поездку по уникальному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Поездка</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<TripDtoGet>> Get(int id)
    {
        var trip = await service.GetTrip(id);
        if (trip == null) 
            return NotFound();
        return Ok(trip);
    }

    /// <summary>
    /// Добавляет новую поездку
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Поездка</returns>
    [HttpPost]
    public async Task<ActionResult<TripDtoGet>> Post([FromBody] TripDtoPost value)
    {
        if (value == null)
            return BadRequest("Trip data is null");

        var newId = await service.PostTrip(value);
        var newTripDto = await service.GetTrip(newId);
        return CreatedAtAction(nameof(Get), new { id = newId }, newTripDto);
    }

    /// <summary>
    /// Обновляет данные о существующей поездке
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns>Обновленная поездка</returns>
    [HttpPut("{id}")]
    public async Task<ActionResult<TripDtoGet>> Put(int id, [FromBody] TripDtoPost value)
    {
        if (value == null)
            return BadRequest("Trip data is null");

        var updatedTrip = await service.PutTrip(id, value);
        if (updatedTrip == null)
            return NotFound($"Trip with id {id} not found");

        return Ok(updatedTrip);
    }

    /// <summary>
    /// Удаляет поездку
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var trip = await service.DeleteTrip(id);
        if (!trip)
            return NotFound();
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using TaxiCompany.Domain.Models;
using TaxiCompany.Domain.Repository;
using TaxiCompany.WebApi.Dto;
using TaxiCompany.WebApi.Services;

namespace TaxiCompany.WebApi.Controllers;

/// <summary>
/// Контроллер для управления клиентами.
/// Предоставляет методы для получения, добавления, обновления и удаления клиентов.
/// </summary>
/// <param name="service"></param>
[Route("api/[controller]")]
[ApiController]
public class UserController(IService service) : ControllerBase
{
    /// <summary>
    /// Получает список клиентов
    /// </summary>
    /// <returns>Список клиентов</returns>
    [HttpGet]
    public ActionResult<IEnumerable<User>> Get()
    {
        return Ok(service.GetUsers());
    }

    /// <summary>
    /// Получает клиента по уникальному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Клиент</returns>
    [HttpGet("{id}")]
    public ActionResult<User> Get(int id)
    {
        var user = service.GetUser(id);
        if (user == null) 
            return NotFound();
        return Ok(user);
    }

    /// <summary>
    /// Добавляет нового клиента
    /// </summary>
    /// <param name="value"></param>
    /// <returns>Новый клиент</returns>
    [HttpPost]
    public ActionResult<UserDtoGet> Post([FromBody] UserDtoPost value)
    {
        if (value == null)
            return BadRequest("User data is null");

        var newId = service.PostUser(value);
        var newUserDto = service.GetUser(newId);
        return CreatedAtAction(nameof(Get), new { id = newId }, newUserDto);
    }

    /// <summary>
    /// Обновляет данные о существующем клиенте
    /// </summary>
    /// <param name="id"></param>
    /// <param name="value"></param>
    /// <returns>Клиент</returns>
    [HttpPut("{id}")]
    public ActionResult<UserDtoGet> Put(int id, [FromBody] UserDtoPost value)
    {
        if (value == null)
            return BadRequest("User data is null");

        var updatedUser = service.PutUser(id, value);
        if (updatedUser == null)
            return NotFound($"User with id {id} not found");

        return Ok(updatedUser);
    }

    /// <summary>
    /// Удаляет клиента
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if(!service.DeleteUser(id))
            return NotFound();
        return Ok();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxiCompany.Domain.Models;

namespace TaxiCompany.Domain.Repository;
/// <summary>
/// Интерфейс основных методов доступа к данным
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Получить все объекты автомобилей
    /// </summary>
    /// <returns>Список автомобилей</returns>
    Task<IEnumerable<Car>> GetCars();
    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Автомобиль</returns>
    Task<Car?> GetCar(int id);
    /// <summary>
    /// Создать новый объект
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новый автомобиль</returns>
    Task<int> PostCar(Car car);
    /// <summary>
    /// Обновить существующий объект
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Обновленный автомобиль</returns>
    Task<bool> PutCar(Car car);
    /// <summary>
    /// Удалить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    Task<bool> DeleteCar(int id);

    /// <summary>
    /// Получить все объекты водителей
    /// </summary>
    /// <returns>Список водителей</returns>
    Task<IEnumerable<Driver>> GetDrivers();
    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Водитель</returns>
    Task<Driver?> GetDriver(int id);
    /// <summary>
    /// Создать новый объект
    /// </summary>
    /// <param name="driver"></param>
    /// <returns>Новый водитель</returns>
    Task<int> PostDriver(Driver driver);
    /// <summary>
    /// Обновить существующий объект
    /// </summary>
    /// <param name="driver"></param>
    /// <returns>Обновленный водитель</returns>
    Task<bool> PutDriver(Driver driver);
    /// <summary>
    /// Удалить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    Task<bool> DeleteDriver(int id);

    /// <summary>
    /// Получить все объекты поездок
    /// </summary>
    /// <returns>Список поездок</returns>
    Task<IEnumerable<Trip>> GetTrips();
    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id">Поездка</param>
    /// <returns></returns>
    Task<Trip?> GetTrip(int id);
    /// <summary>
    /// Создать новый объект
    /// </summary>
    /// <param name="trip"></param>
    /// <returns>Новая поездка</returns>
    Task<int> PostTrip(Trip trip);
    /// <summary>
    /// Обновить существующий объект
    /// </summary>
    /// <param name="trip"></param>
    /// <returns>Обновленная поездка</returns>
    Task<bool> PutTrip(Trip trip);
    /// <summary>
    /// Удалить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    Task<bool> DeleteTrip(int id);

    /// <summary>
    /// Получить все объекты клиентов
    /// </summary>
    /// <returns>Список клиентов</returns>
    Task<IEnumerable<User>> GetUsers();
    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Клиент</returns>
    Task<User?> GetUser(int id);
    /// <summary>
    /// Создать новый объект
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Новый клиент</returns>
    Task<int> PostUser(User user);
    /// <summary>
    /// Обновить существующий объект
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Обновленный клиент</returns>
    Task<bool> PutUser(User user);
    /// <summary>
    /// Удалить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    Task<bool> DeleteUser(int id);
}

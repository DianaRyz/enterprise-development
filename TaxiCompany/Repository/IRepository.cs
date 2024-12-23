using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    public IEnumerable<Car> GetCars();
    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Автомобиль</returns>
    public Car? GetCar(int id);
    /// <summary>
    /// Создать новый объект
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новый автомобиль</returns>
    public int PostCar(Car car);
    /// <summary>
    /// Обновить существующий объект
    /// </summary>
    /// <param name="id"></param>
    /// <param name="car"></param>
    /// <returns>Обновленный автомобиль</returns>
    public bool PutCar(int id, Car car);
    /// <summary>
    /// Удалить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    public bool DeleteCar(int id);

    /// <summary>
    /// Получить все объекты водителей
    /// </summary>
    /// <returns>Список водителей</returns>
    public IEnumerable<Driver> GetDrivers();
    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Водитель</returns>
    public Driver? GetDriver(int id);
    /// <summary>
    /// Создать новый объект
    /// </summary>
    /// <param name="driver"></param>
    /// <returns>Новый водитель</returns>
    public int PostDriver(Driver driver);
    /// <summary>
    /// Обновить существующий объект
    /// </summary>
    /// <param name="id"></param>
    /// <param name="driver"></param>
    /// <returns>Обновленный водитель</returns>
    public bool PutDriver(int id, Driver driver);
    /// <summary>
    /// Удалить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    public bool DeleteDriver(int id);

    /// <summary>
    /// Получить все объекты поездок
    /// </summary>
    /// <returns>Список поездок</returns>
    public IEnumerable<Trip> GetTrips();
    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id">Поездка</param>
    /// <returns></returns>
    public Trip? GetTrip(int id);
    /// <summary>
    /// Создать новый объект
    /// </summary>
    /// <param name="trip"></param>
    /// <returns>Новая поездка</returns>
    public int PostTrip(Trip trip);
    /// <summary>
    /// Обновить существующий объект
    /// </summary>
    /// <param name="id"></param>
    /// <param name="trip"></param>
    /// <returns>Обновленная поездка</returns>
    public bool PutTrip(int id, Trip trip);
    /// <summary>
    /// Удалить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    public bool DeleteTrip(int id);

    /// <summary>
    /// Получить все объекты клиентов
    /// </summary>
    /// <returns>Список клиентов</returns>
    public IEnumerable<User> GetUsers();
    /// <summary>
    /// Получить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Клиент</returns>
    public User? GetUser(int id);
    /// <summary>
    /// Создать новый объект
    /// </summary>
    /// <param name="user"></param>
    /// <returns>Новый клиент</returns>
    public int PostUser(User user);
    /// <summary>
    /// Обновить существующий объект
    /// </summary>
    /// <param name="id"></param>
    /// <param name="user"></param>
    /// <returns>Обновленный клиент</returns>
    public bool PutUser(int id, User user);
    /// <summary>
    /// Удалить объект по идентификатору
    /// </summary>
    /// <param name="id"></param>
    public bool DeleteUser(int id);
}

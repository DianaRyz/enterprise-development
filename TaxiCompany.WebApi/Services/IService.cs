using TaxiCompany.Domain;
using TaxiCompany.WebApi.Dto;

namespace TaxiCompany.WebApi.Services;

/// <summary>
/// Интерфейс для сервисов сущностей.
/// Определяет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с сущностями.
/// </summary>
public interface IService
{
    /// <summary>
    /// Получает все объекты автомобилей из репозитория
    /// </summary>
    /// <returns>Список автомобилей</returns>
    IEnumerable<CarDtoGet> GetCars();
    /// <summary>
    /// Получает объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Автомобиль</returns>
    CarDtoGet? GetCar(int id);
    /// <summary>
    /// Создает новый объект на основе предоставленного DTO
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новый автомобиль</returns>
    int PostCar(CarDtoPost car);
    /// <summary>
    /// Обновляет существующий объект по указанному идентификатору, используя данные из DTO
    /// </summary>
    /// <param name="id"></param>
    /// <param name="car"></param>
    /// <returns>Обновленный автомобиль</returns>
    CarDtoGet? PutCar(int id, CarDtoPost car);
    /// <summary>
    /// Удаляет объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    bool DeleteCar(int id);

    /// <summary>
    /// Получает все объекты водителей из репозитория
    /// </summary>
    /// <returns>Список водителей</returns>
    IEnumerable<DriverDtoGet> GetDrivers();
    /// <summary>
    /// Получает объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Водитель</returns>
    DriverDtoGet? GetDriver(int id);
    /// <summary>
    /// Создает новый объект на основе предоставленного DTO
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новый водитель</returns>
    int PostDriver(DriverDtoPost car);
    /// <summary>
    /// Обновляет существующий объект по указанному идентификатору, используя данные из DTO
    /// </summary>
    /// <param name="id"></param>
    /// <param name="car"></param>
    /// <returns>Обновленный водитель</returns>
    DriverDtoGet? PutDriver(int id, DriverDtoPost car);
    /// <summary>
    /// Удаляет объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    bool DeleteDriver(int id);

    /// <summary>
    /// Получает все объекты поездок из репозитория
    /// </summary>
    /// <returns>Список поездок</returns>
    IEnumerable<TripDtoGet> GetTrips();
    /// <summary>
    /// Получает объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Поездка</returns>
    TripDtoGet? GetTrip(int id);
    /// <summary>
    /// Создает новый объект на основе предоставленного DTO
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новая поездка</returns>
    int PostTrip(TripDtoPost car);
    /// <summary>
    /// Обновляет существующий объект по указанному идентификатору, используя данные из DTO
    /// </summary>
    /// <param name="id"></param>
    /// <param name="car"></param>
    /// <returns>Обновленная поездка</returns>
    TripDtoGet? PutTrip(int id, TripDtoPost car);
    /// <summary>
    /// Удаляет объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    bool DeleteTrip(int id);

    /// <summary>
    /// Получает все объекты клиентов из репозитория
    /// </summary>
    /// <returns>Список клиентов</returns>
    IEnumerable<UserDtoGet> GetUsers();
    /// <summary>
    /// Получает объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Клиент</returns>
    UserDtoGet? GetUser(int id);
    /// <summary>
    /// Создает новый объект на основе предоставленного DTO
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новый клиент</returns>
    int PostUser(UserDtoPost car);
    /// <summary>
    /// Обновляет существующий объект по указанному идентификатору, используя данные из DTO
    /// </summary>
    /// <param name="id"></param>
    /// <param name="car"></param>
    /// <returns>Обновленный клиент</returns>
    UserDtoGet? PutUser(int id, UserDtoPost car);
    /// <summary>
    /// Удаляет объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    bool DeleteUser(int id);

}



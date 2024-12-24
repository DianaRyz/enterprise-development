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
    Task<IEnumerable<CarDtoGet>> GetCars();
    /// <summary>
    /// Получает объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Автомобиль</returns>
    Task<CarDtoGet?> GetCar(int id);
    /// <summary>
    /// Создает новый объект на основе предоставленного DTO
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новый автомобиль</returns>
    Task<int> PostCar(CarDtoPost car);
    /// <summary>
    /// Обновляет существующий объект по указанному идентификатору, используя данные из DTO
    /// </summary>
    /// <param name="id"></param>
    /// <param name="car"></param>
    /// <returns>Обновленный автомобиль</returns>
    Task<CarDtoGet?> PutCar(int id, CarDtoPost car);
    /// <summary>
    /// Удаляет объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    Task<bool> DeleteCar(int id);

    /// <summary>
    /// Получает все объекты водителей из репозитория
    /// </summary>
    /// <returns>Список водителей</returns>
    Task<IEnumerable<DriverDtoGet>> GetDrivers();
    /// <summary>
    /// Получает объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Водитель</returns>
    Task<DriverDtoGet?> GetDriver(int id);
    /// <summary>
    /// Создает новый объект на основе предоставленного DTO
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новый водитель</returns>
    Task<int> PostDriver(DriverDtoPost car);
    /// <summary>
    /// Обновляет существующий объект по указанному идентификатору, используя данные из DTO
    /// </summary>
    /// <param name="id"></param>
    /// <param name="car"></param>
    /// <returns>Обновленный водитель</returns>
    Task<DriverDtoGet?> PutDriver(int id, DriverDtoPost car);
    /// <summary>
    /// Удаляет объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    Task<bool> DeleteDriver(int id);

    /// <summary>
    /// Получает все объекты поездок из репозитория
    /// </summary>
    /// <returns>Список поездок</returns>
    Task<IEnumerable<TripDtoGet>> GetTrips();
    /// <summary>
    /// Получает объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Поездка</returns>
    Task<TripDtoGet?> GetTrip(int id);
    /// <summary>
    /// Создает новый объект на основе предоставленного DTO
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новая поездка</returns>
    Task<int> PostTrip(TripDtoPost car);
    /// <summary>
    /// Обновляет существующий объект по указанному идентификатору, используя данные из DTO
    /// </summary>
    /// <param name="id"></param>
    /// <param name="car"></param>
    /// <returns>Обновленная поездка</returns>
    Task<TripDtoGet?> PutTrip(int id, TripDtoPost car);
    /// <summary>
    /// Удаляет объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    Task<bool> DeleteTrip(int id);

    /// <summary>
    /// Получает все объекты клиентов из репозитория
    /// </summary>
    /// <returns>Список клиентов</returns>
    Task<IEnumerable<UserDtoGet>> GetUsers();
    /// <summary>
    /// Получает объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Клиент</returns>
    Task<UserDtoGet?> GetUser(int id);
    /// <summary>
    /// Создает новый объект на основе предоставленного DTO
    /// </summary>
    /// <param name="car"></param>
    /// <returns>Новый клиент</returns>
    Task<int> PostUser(UserDtoPost car);
    /// <summary>
    /// Обновляет существующий объект по указанному идентификатору, используя данные из DTO
    /// </summary>
    /// <param name="id"></param>
    /// <param name="car"></param>
    /// <returns>Обновленный клиент</returns>
    Task<UserDtoGet?> PutUser(int id, UserDtoPost car);
    /// <summary>
    /// Удаляет объект по указанному идентификатору
    /// </summary>
    /// <param name="id"></param>
    Task<bool> DeleteUser(int id);

}



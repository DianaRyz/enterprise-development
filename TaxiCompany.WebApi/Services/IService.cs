using TaxiCompany.Domain;
using TaxiCompany.WebApi.Dto;

namespace TaxiCompany.WebApi.Services;

/// <summary>
/// Интерфейс для сервисов сущностей.
/// Определяет методы для выполнения операций CRUD (создание, чтение, обновление, удаление) с сущностями.
/// </summary>
public interface IService
{
    IEnumerable<CarDtoGet> GetCars();
    CarDtoGet? GetCar(int id);
    int PostCar(CarDtoPost car);
    CarDtoGet? PutCar(int id, CarDtoPost car);
    bool DeleteCar(int id);

    IEnumerable<DriverDtoGet> GetDrivers();
    DriverDtoGet? GetDriver(int id);
    int PostDriver(DriverDtoPost car);
    DriverDtoGet? PutDriver(int id, DriverDtoPost car);
    bool DeleteDriver(int id);

    IEnumerable<TripDtoGet> GetTrips();
    TripDtoGet? GetTrip(int id);
    int PostTrip(TripDtoPost car);
    TripDtoGet? PutTrip(int id, TripDtoPost car);
    bool DeleteTrip(int id);

    IEnumerable<UserDtoGet> GetUsers();
    UserDtoGet? GetUser(int id);
    int PostUser(UserDtoPost car);
    UserDtoGet? PutUser(int id, UserDtoPost car);
    bool DeleteUser(int id);

}



using AutoMapper;
using System.Diagnostics;
using TaxiCompany.Domain;
using TaxiCompany.Domain.Repository;
using TaxiCompany.WebApi.Dto;

namespace TaxiCompany.WebApi.Services;
/// <summary>
/// Сервис предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление)
/// </summary>
/// <param name="_mapper"></param>
/// <param name="_repository"></param>
public class Service(IMapper _mapper, IRepository _repository) : IService
{
    /// <inheritdoc />
    public IEnumerable<CarDtoGet> GetCars()
    {
        var cars = _repository.GetCars();
        return _mapper.Map<IEnumerable<CarDtoGet>>(cars);
    }
    /// <inheritdoc />
    public IEnumerable<DriverDtoGet> GetDrivers()
    {
        var drivers = _repository.GetDrivers();
        return _mapper.Map<IEnumerable<DriverDtoGet>>(drivers);
    }
    /// <inheritdoc />
    public IEnumerable<TripDtoGet> GetTrips()
    {
        var trips = _repository.GetTrips();
        return _mapper.Map<IEnumerable<TripDtoGet>>(trips);
    }
    /// <inheritdoc />
    public IEnumerable<UserDtoGet> GetUsers()
    {
        var users = _repository.GetUsers();
        return _mapper.Map<IEnumerable<UserDtoGet>>(users);
    }

    /// <inheritdoc />
    public CarDtoGet? GetCar(int id)
    {
        var car = _repository.GetCar(id);
        return _mapper.Map<CarDtoGet>(car);
    }
    /// <inheritdoc />
    public DriverDtoGet? GetDriver(int id)
    {
        var driver = _repository.GetDriver(id);
        return _mapper.Map<DriverDtoGet>(driver);
    }
    /// <inheritdoc />
    public TripDtoGet? GetTrip(int id)
    {
        var trip = _repository.GetTrip(id);
        return _mapper.Map<TripDtoGet>(trip);
    }
    /// <inheritdoc />
    public UserDtoGet? GetUser(int id)
    {
        var user = _repository.GetUser(id);
        return _mapper.Map<UserDtoGet>(user);
    }
    /// <inheritdoc />
    public int PostCar(CarDtoPost postCar)
    {
        var car = _mapper.Map<Car>(postCar);
        var newCarId = _repository.PostCar(car);

        if (postCar.AssignedDriverId != 0)
        {
            var driver = _repository.GetDriver(postCar.AssignedDriverId);
            if (driver != null)
            {
                driver.AssignedCarId = newCarId;
                _repository.PutDriver(driver.DriverId, driver); 
            }
        }

        return newCarId;
    }
    /// <inheritdoc />
    public int PostDriver(DriverDtoPost postDriver)
    {
        var driver = _mapper.Map<Driver>(postDriver);
        var newDriverId = _repository.PostDriver(driver);

        if (postDriver.AssignedCarId != 0)
        {
            var car = _repository.GetCar(postDriver.AssignedCarId);
            if (car != null)
            {
                car.AssignedDriverId = newDriverId;
                _repository.PutCar(car.CarId, car); 
            }
        }

        return newDriverId;
    }
    /// <inheritdoc />
    public int PostTrip(TripDtoPost postTrip)
    {
        var trip = _mapper.Map<Trip>(postTrip);
        return _repository.PostTrip(trip);
    }
    /// <inheritdoc />
    public int PostUser(UserDtoPost postUser)
    {
        var user = _mapper.Map<User>(postUser);
        return _repository.PostUser(user);
    }
    /// <inheritdoc />
    public CarDtoGet? PutCar(int id, CarDtoPost putDto)
    {
        var oldValue = _repository.GetCar(id);
        if (oldValue == null)
            return null;

        var updatedCar = _mapper.Map(putDto, oldValue);
        _repository.PutCar(id, updatedCar);
        return _mapper.Map<CarDtoGet>(updatedCar);
    }
    /// <inheritdoc />
    public DriverDtoGet? PutDriver(int id, DriverDtoPost putDto)
    {
        var oldValue = _repository.GetDriver(id);
        if (oldValue == null)
            return null;

        var updatedDriver = _mapper.Map(putDto, oldValue);
        _repository.PutDriver(id, updatedDriver);
        return _mapper.Map<DriverDtoGet>(updatedDriver);
    }
    /// <inheritdoc />
    public TripDtoGet? PutTrip(int id, TripDtoPost putDto)
    {
        var oldValue = _repository.GetTrip(id);
        if (oldValue == null)
            return null;

        var updatedTrip = _mapper.Map(putDto, oldValue);
        _repository.PutTrip(id, updatedTrip);
        return _mapper.Map<TripDtoGet>(updatedTrip);
    }
    /// <inheritdoc />
    public UserDtoGet? PutUser(int id, UserDtoPost putDto)
    {
        var oldValue = _repository.GetUser(id);
        if (oldValue == null)
            return null;

        var updatedUser = _mapper.Map(putDto, oldValue);
        _repository.PutUser(id, updatedUser);
        return _mapper.Map<UserDtoGet>(updatedUser);
    }
    /// <inheritdoc />
    public bool DeleteCar(int id)
    {
        return _repository.DeleteCar(id);
    }
    /// <inheritdoc />
    public bool DeleteDriver(int id)
    {
        return _repository.DeleteDriver(id);
    }
    /// <inheritdoc />
    public bool DeleteTrip(int id)
    {
        return _repository.DeleteTrip(id);
    }
    /// <inheritdoc />
    public bool DeleteUser(int id)
    {
        return _repository.DeleteUser(id);
    }

}

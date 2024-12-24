using AutoMapper;
using System.Diagnostics;
using TaxiCompany.Domain.Models;
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
    public async Task<IEnumerable<CarDtoGet>> GetCars()
    {
        var cars = await _repository.GetCars();
        return _mapper.Map<IEnumerable<CarDtoGet>>(cars);
    }
    /// <inheritdoc />
    public async Task<IEnumerable<DriverDtoGet>> GetDrivers()
    {
        var drivers = await _repository.GetDrivers();
        return _mapper.Map<IEnumerable<DriverDtoGet>>(drivers);
    }
    /// <inheritdoc />
    public async Task<IEnumerable<TripDtoGet>> GetTrips()
    {
        var trips = await _repository.GetTrips();
        return _mapper.Map<IEnumerable<TripDtoGet>>(trips);
    }
    /// <inheritdoc />
    public async Task<IEnumerable<UserDtoGet>> GetUsers()
    {
        var users = await _repository.GetUsers();
        return _mapper.Map<IEnumerable<UserDtoGet>>(users);
    }

    /// <inheritdoc />
    public async Task<CarDtoGet?> GetCar(int id)
    {
        var car = await _repository.GetCar(id);
        return _mapper.Map<CarDtoGet>(car);
    }
    /// <inheritdoc />
    public async Task<DriverDtoGet?> GetDriver(int id)
    {
        var driver = await _repository.GetDriver(id);
        return _mapper.Map<DriverDtoGet>(driver);
    }
    /// <inheritdoc />
    public async Task<TripDtoGet?> GetTrip(int id)
    {
        var trip = await _repository.GetTrip(id);
        return _mapper.Map<TripDtoGet>(trip);
    }
    /// <inheritdoc />
    public async Task<UserDtoGet?> GetUser(int id)
    {
        var user = await _repository.GetUser(id);
        return _mapper.Map<UserDtoGet>(user);
    }
    /// <inheritdoc />
    public async Task<int> PostCar(CarDtoPost postCar)
    {
        var car = _mapper.Map<Car>(postCar);
        var newCarId = await _repository.PostCar(car);

        if (postCar.AssignedDriverId != 0)
        {
            var driver = await _repository.GetDriver(postCar.AssignedDriverId);
            if (driver != null)
            {
                driver.AssignedCarId = newCarId;
                await _repository.PutDriver(driver); 
            }
        }

        return newCarId;
    }
    /// <inheritdoc />
    public async Task<int> PostDriver(DriverDtoPost postDriver)
    {
        var driver = _mapper.Map<Driver>(postDriver);
        var newDriverId = await _repository.PostDriver(driver);

        if (postDriver.AssignedCarId != 0)
        {
            var car = await _repository.GetCar(postDriver.AssignedCarId);
            if (car != null)
            {
                car.AssignedDriverId = newDriverId;
                await _repository.PutCar(car); 
            }
        }

        return newDriverId;
    }
    /// <inheritdoc />
    public async Task<int> PostTrip(TripDtoPost postTrip)
    {
        var trip = _mapper.Map<Trip>(postTrip);
        return await _repository.PostTrip(trip);
    }
    /// <inheritdoc />
    public async Task<int> PostUser(UserDtoPost postUser)
    {
        var user = _mapper.Map<User>(postUser);
        return await _repository.PostUser(user);
    }
    /// <inheritdoc />
    public async Task<CarDtoGet?> PutCar(int id, CarDtoPost putDto)
    {
        var oldValue = await _repository.GetCar(id);
        if (oldValue == null)
            return null;

        var updatedCar = _mapper.Map(putDto, oldValue);
        await _repository.PutCar(updatedCar);
        return _mapper.Map<CarDtoGet>(updatedCar);
    }
    /// <inheritdoc />
    public async Task<DriverDtoGet?> PutDriver(int id, DriverDtoPost putDto)
    {
        var oldValue = await _repository.GetDriver(id);
        if (oldValue == null)
            return null;

        var updatedDriver = _mapper.Map(putDto, oldValue);
        await _repository.PutDriver(updatedDriver);
        return _mapper.Map<DriverDtoGet>(updatedDriver);
    }
    /// <inheritdoc />
    public async Task<TripDtoGet?> PutTrip(int id, TripDtoPost putDto)
    {
        var oldValue = await _repository.GetTrip(id);
        if (oldValue == null)
            return null;

        var updatedTrip = _mapper.Map(putDto, oldValue);
        await _repository.PutTrip(updatedTrip);
        return _mapper.Map<TripDtoGet>(updatedTrip);
    }
    /// <inheritdoc />
    public async Task<UserDtoGet?> PutUser(int id, UserDtoPost putDto)
    {
        var oldValue = await _repository.GetUser(id);
        if (oldValue == null)
            return null;

        var updatedUser = _mapper.Map(putDto, oldValue);
        await _repository.PutUser(updatedUser);
        return _mapper.Map<UserDtoGet>(updatedUser);
    }
    /// <inheritdoc />
    public async Task<bool> DeleteCar(int id)
    {
        return await _repository.DeleteCar(id);
    }
    /// <inheritdoc />
    public async Task<bool> DeleteDriver(int id)
    {
        return await _repository.DeleteDriver(id);
    }
    /// <inheritdoc />
    public async Task<bool> DeleteTrip(int id)
    {
        return await _repository.DeleteTrip(id);
    }
    /// <inheritdoc />
    public async Task<bool> DeleteUser(int id)
    {
        return await _repository.DeleteUser(id);
    }

}

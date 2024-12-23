using System.Diagnostics;
using TaxiCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace TaxiCompany.Domain.Repository;
/// <summary>
/// Репозиторий для работы с данными
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление)
/// </summary>
public class Repository(TaxiCompanyContext context) : IRepository
{
    /// <inheritdoc />
    public bool DeleteCar(int id)
    {
        var car = GetCar(id);
        if (car == null)
            return false;

        context.Cars.Remove(car);
        context.SaveChanges();
        return true;
    }
    /// <inheritdoc />
    public bool DeleteDriver(int id)
    {
        var driver = GetDriver(id);
        if (driver == null)
            return false;
        context.Drivers.Remove(driver);
        context.SaveChanges();
        return true;
    }
    /// <inheritdoc />
    public bool DeleteTrip(int id)
    {
        var trip = GetTrip(id);
        if (trip == null)
            return false;
        context.Trips.Remove(trip);
        context.SaveChanges();
        return true;
    }
    /// <inheritdoc />
    public bool DeleteUser(int id)
    {
        var user = GetUser(id);
        if (user == null)
            return false;
        context.Users.Remove(user);
        context.SaveChanges();
        return true;
    }

    /// <inheritdoc />
    public Car? GetCar(int id) => context.Cars.FirstOrDefault(c => c.CarId == id);
    /// <inheritdoc />
    public IEnumerable<Car> GetCars() => context.Cars.ToList();
    /// <inheritdoc />
    public Driver? GetDriver(int id) => context.Drivers.FirstOrDefault(d => d.DriverId == id);
    /// <inheritdoc />
    public IEnumerable<Driver> GetDrivers() => context.Drivers.ToList();
    /// <inheritdoc />
    public Trip? GetTrip(int id) => context.Trips.FirstOrDefault(t => t.TripId == id);
    /// <inheritdoc />
    public IEnumerable<Trip> GetTrips() => context.Trips.ToList();
    /// <inheritdoc />
    public User? GetUser(int id) => context.Users.FirstOrDefault(u => u.UserId == id);
    /// <inheritdoc />
    public IEnumerable<User> GetUsers() => context.Users.ToList();

    /// <inheritdoc />
    public int PostCar(Car car)
    {
        context.Cars.Add(car);
        context.SaveChanges();
        return car.CarId;
    }
    /// <inheritdoc />
    public int PostDriver(Driver driver)
    {
        context.Drivers.Add(driver);
        context.SaveChanges();
        return driver.DriverId;
    }
    /// <inheritdoc />
    public int PostTrip(Trip trip)
    {
        context.Trips.Add(trip);
        context.SaveChanges();
        return trip.TripId;
    }
    /// <inheritdoc />
    public int PostUser(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
        return user.UserId;
    }

    /// <inheritdoc />
    public bool PutCar(Car car)
    {
        var oldValue = GetCar(car.CarId);
        if (oldValue == null)
            return false;
        context.Entry(oldValue).CurrentValues.SetValues(car);
        context.SaveChanges();
        return true;
    }
    /// <inheritdoc />
    public bool PutDriver(Driver driver)
    {
        var oldValue = GetDriver(driver.DriverId);
        if (oldValue == null)
            return false;
        context.Entry(oldValue).CurrentValues.SetValues(driver);
        context.SaveChanges();
        return true;
    }
    /// <inheritdoc />
    public bool PutTrip(Trip trip)
    {
        var oldValue = GetTrip(trip.TripId);
        if (oldValue == null)
            return false;
        context.Entry(oldValue).CurrentValues.SetValues(trip);
        context.SaveChanges();
        return true;
    }
    /// <inheritdoc />
    public bool PutUser(User user)
    {
        var oldValue = GetUser(user.UserId);
        if (oldValue == null)
            return false;
        context.Entry(oldValue).CurrentValues.SetValues(user);
        context.SaveChanges();
        return true;
    }
}

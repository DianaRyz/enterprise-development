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
    public async Task<bool> DeleteCar(int id)
    {
        var car = await GetCar(id);
        if (car == null)
            return false;

        context.Cars.Remove(car);
        await context.SaveChangesAsync();
        return true;
    }
    /// <inheritdoc />
    public async Task<bool> DeleteDriver(int id)
    {
        var driver = await GetDriver(id);
        if (driver == null)
            return false;
        context.Drivers.Remove(driver);
        await context.SaveChangesAsync();
        return true;
    }
    /// <inheritdoc />
    public async Task<bool> DeleteTrip(int id)
    {
        var trip = await GetTrip(id);
        if (trip == null)
            return false;
        context.Trips.Remove(trip);
        await context.SaveChangesAsync();
        return true;
    }
    /// <inheritdoc />
    public async Task<bool> DeleteUser(int id)
    {
        var user = await GetUser(id);
        if (user == null)
            return false;
        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }

    /// <inheritdoc />
    public async Task<Car?> GetCar(int id) => await context.Cars.FirstOrDefaultAsync(c => c.CarId == id);
    /// <inheritdoc />
    public async Task<IEnumerable<Car>> GetCars() => await context.Cars.ToListAsync();
    /// <inheritdoc />
    public async Task<Driver?> GetDriver(int id) => await context.Drivers.FirstOrDefaultAsync(d => d.DriverId == id);
    /// <inheritdoc />
    public async Task<IEnumerable<Driver>> GetDrivers() => await context.Drivers.ToListAsync();
    /// <inheritdoc />
    public async Task<Trip?> GetTrip(int id) => await context.Trips.FirstOrDefaultAsync(t => t.TripId == id);
    /// <inheritdoc />
    public async Task<IEnumerable<Trip>> GetTrips() => await context.Trips.ToListAsync();
    /// <inheritdoc />
    public async Task<User?> GetUser(int id) => await context.Users.FirstOrDefaultAsync(u => u.UserId == id);
    /// <inheritdoc />
    public async Task<IEnumerable<User>> GetUsers() => await context.Users.ToListAsync();

    /// <inheritdoc />
    public async Task<int> PostCar(Car car)
    {
        await context.Cars.AddAsync(car);
        await context.SaveChangesAsync();
        return car.CarId;
    }
    /// <inheritdoc />
    public async Task<int> PostDriver(Driver driver)
    {
        await context.Drivers.AddAsync(driver);
        await context.SaveChangesAsync();
        return driver.DriverId;
    }
    /// <inheritdoc />
    public async Task<int> PostTrip(Trip trip)
    {
        await context.Trips.AddAsync(trip);
        await context.SaveChangesAsync();
        return trip.TripId;
    }
    /// <inheritdoc />
    public async Task<int> PostUser(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user.UserId;
    }

    /// <inheritdoc />
    public async Task<bool> PutCar(Car car)
    {
        var oldValue = await GetCar(car.CarId);
        if (oldValue == null)
            return false;
        context.Entry(oldValue).CurrentValues.SetValues(car);
        await context.SaveChangesAsync();
        return true;
    }
    /// <inheritdoc />
    public async Task<bool> PutDriver(Driver driver)
    {
        var oldValue = await GetDriver(driver.DriverId);
        if (oldValue == null)
            return false;
        context.Entry(oldValue).CurrentValues.SetValues(driver);
        await context.SaveChangesAsync();
        return true;
    }
    /// <inheritdoc />
    public async Task<bool> PutTrip(Trip trip)
    {
        var oldValue = await GetTrip(trip.TripId);
        if (oldValue == null)
            return false;
        context.Entry(oldValue).CurrentValues.SetValues(trip);
        await context.SaveChangesAsync();
        return true;
    }
    /// <inheritdoc />
    public async Task<bool> PutUser(User user)
    {
        var oldValue = await GetUser(user.UserId);
        if (oldValue == null)
            return false;
        context.Entry(oldValue).CurrentValues.SetValues(user);
        await context.SaveChangesAsync();
        return true;
    }
}

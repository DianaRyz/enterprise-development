using System.Diagnostics;

namespace TaxiCompany.Domain.Repository;
/// <summary>
/// Репозиторий для работы с данными
/// Предоставляет методы для выполнения операций CRUD (создание, чтение, обновление, удаление)
/// </summary>
public class Repository : IRepository
{
    private readonly List<Car> _cars = [];
    private readonly List<Driver> _drivers = [];
    private readonly List<Trip> _trips = [];
    private readonly List<User> _users = [];

    /// <inheritdoc />
    public bool DeleteCar(int id)
    {
        var car = GetCar(id);
        if (car == null)
            return false;
        _cars.Remove(car);
        return true;
    }
    /// <inheritdoc />
    public bool DeleteDriver(int id)
    {
        var driver = GetDriver(id);
        if (driver == null)
            return false;
        _drivers.Remove(driver);
        return true;
    }
    /// <inheritdoc />
    public bool DeleteTrip(int id)
    {
        var trip = GetTrip(id);
        if (trip == null)
            return false;
        _trips.Remove(trip);
        return true;
    }
    /// <inheritdoc />
    public bool DeleteUser(int id)
    {
        var user = GetUser(id);
        if (user == null)
            return false;
        _users.Remove(user);
        return true;
    }

    /// <inheritdoc />
    public Car? GetCar(int id) => _cars.Find(c => c.CarId == id);
    /// <inheritdoc />
    public IEnumerable<Car> GetCars() => _cars;
    /// <inheritdoc />
    public Driver? GetDriver(int id) => _drivers.Find(d => d.DriverId == id);
    /// <inheritdoc />
    public IEnumerable<Driver> GetDrivers() => _drivers;
    /// <inheritdoc />
    public Trip? GetTrip(int id) => _trips.Find(t => t.TripId == id);
    /// <inheritdoc />
    public IEnumerable<Trip> GetTrips() => _trips;
    /// <inheritdoc />
    public User? GetUser(int id) => _users.Find(u => u.UserId == id);
    /// <inheritdoc />
    public IEnumerable<User> GetUsers() => _users;

    /// <inheritdoc />
    public int PostCar(Car car)
    {
        var newId = _cars.Count > 0 ? _cars.Max(g => g.CarId) + 1 : 1;
        car.CarId = newId;
        _cars.Add(car);
        return newId;
    }
    /// <inheritdoc />
    public int PostDriver(Driver driver)
    {
        var newId = _drivers.Count > 0 ? _drivers.Max(g => g.DriverId) + 1 : 1;
        driver.DriverId = newId;
        _drivers.Add(driver);
        return newId;
    }
    /// <inheritdoc />
    public int PostTrip(Trip trip)
    {
        var newId = _trips.Count > 0 ? _trips.Max(g => g.TripId) + 1 : 1;
        trip.TripId = newId;
        _trips.Add(trip);
        return newId;
    }
    /// <inheritdoc />
    public int PostUser(User user)
    {
        var newId = _users.Count > 0 ? _users.Max(g => g.UserId) + 1 : 1;
        user.UserId = newId;
        _users.Add(user);
        return newId;
    }
    /// <inheritdoc />
    public bool PutCar(int id, Car car)
    {
        var oldValue = GetCar(id);
        if (oldValue == null)
            return false;
        oldValue.Colour = car.Colour;
        oldValue.Model = car.Model;
        oldValue.StateNumber = car.StateNumber;
        oldValue.AssignedDriverId = car.AssignedDriverId;
        return true;
    }
    /// <inheritdoc />
    public bool PutDriver(int id, Driver driver)
    {
        var oldValue = GetDriver(id);
        if (oldValue == null)
            return false;
        oldValue.FullName = driver.FullName;
        oldValue.PhoneNumber = driver.PhoneNumber;
        oldValue.Passport = driver.Passport;
        oldValue.Address = driver.Address;
        oldValue.AssignedCarId = driver.AssignedCarId;
        return true;
    }
    /// <inheritdoc />
    public bool PutTrip(int id, Trip trip)
    {
        var oldValue = GetTrip(id);
        if (oldValue == null)
            return false;
        oldValue.Departure = trip.Departure;
        oldValue.Destination = trip.Destination;
        oldValue.Date = trip.Date;
        oldValue.DrivingTime = trip.DrivingTime;
        oldValue.Cost = trip.Cost;
        oldValue.AssignedUserId = trip.AssignedUserId;
        oldValue.AssignedCarId = trip.AssignedCarId;
        return true;
    }
    /// <inheritdoc />
    public bool PutUser(int id, User user)
    {
        var oldValue = GetUser(id);
        if (oldValue == null)
            return false;
        oldValue.FullName = user.FullName;
        oldValue.PhoneNumber = user.PhoneNumber;
        return true;
    }
}

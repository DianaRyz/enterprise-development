using TaxiCompany.Domain;

namespace TaxiCompany.Tests;
/// <summary>
/// Класс для проведения юнит-тестов
/// </summary>
public class TaxiCompanyTests(TaxiCompanyFixture fixture) : IClassFixture<TaxiCompanyFixture>
{
    private readonly TaxiCompanyFixture _fixture = fixture;
    /// <summary>
    /// Выводит все сведения о конкретном водителе и его автомобиле
    /// </summary>
    [Fact]
    public void ReturnCarDriverInfo()
    {    
        var driverId = 1;
        var expectedDriver = _fixture.Drivers[0];
        var expectedCar = _fixture.Cars[0];

        var result = _fixture.Drivers
            .Join(_fixture.Cars,
                  driver => driver.AssignedCarId,
                  car => car.CarId,
                  (driver, car) => new { Driver = driver, Car = car })
            .Where(x => x.Driver.DriverId == driverId)
            .FirstOrDefault();

        Assert.NotNull(result);
        Assert.Equal(expectedDriver, result.Driver);
        Assert.Equal(expectedCar, result.Car);
    }
    /// <summary>
    /// Выводит всех пассажиров, совершивших поездки за заданный период, упорядочивая по ФИО
    /// </summary>
    [Fact]
    public void ReturnUsersDateInfo()
    {
        DateTime startDate = new(2024, 1, 1);
        DateTime endDate = new(2024, 4, 1);

        var expectedUsersName = new List<User>
        {
            _fixture.Users[0],
            _fixture.Users[1],
            _fixture.Users[2]
        };
        var result = _fixture.Trips
            .Where(t => t.Date >= startDate && t.Date <= endDate)
            .Select(t => _fixture.Users.First(c => c.UserId == t.AssignedUserId))
            .Distinct()
            .OrderBy(c => c.FullName)
            .ToList();

        Assert.Equal(expectedUsersName, result);
    }
    /// <summary>
    /// Выводит количество поездок каждого пассажира
    /// </summary>
    [Fact]
    public void ReturnTravelsCount()
    {
        var expectedData = new[]
        {
            new { Client = _fixture.Users[0], TripCount = 2 },
            new { Client = _fixture.Users[1], TripCount = 1 },
            new { Client = _fixture.Users[2], TripCount = 1 },
            new { Client = _fixture.Users[3], TripCount = 1 },
            new { Client = _fixture.Users[4], TripCount = 1 },
            new { Client = _fixture.Users[5], TripCount = 1 },
            new { Client = _fixture.Users[6], TripCount = 1 },
            new { Client = _fixture.Users[7], TripCount = 1 },
            new { Client = _fixture.Users[8], TripCount = 1 },
            new { Client = _fixture.Users[9], TripCount = 0 }
        };

        var result = _fixture.Users
            .GroupJoin(
                _fixture.Trips,
                client => client.UserId,
                trip => trip.AssignedUserId,
                (client, trips) => new
                {
                    Client = client,
                    TripCount = trips.Count()
                }
            )
            .ToList();

        Assert.Equal(expectedData, result);
    }
    /// <summary>
    ///  Выводит топ 5 водителей по совершенному количеству поездок
    /// </summary>
    [Fact]
    public void ReturnTopFiveDrives()
    {
        var expectedData = new[]
        {
            new { Driver = _fixture.Drivers[0], TripCount = 2 },
            new { Driver = _fixture.Drivers[1], TripCount = 2 },
            new { Driver = _fixture.Drivers[2], TripCount = 2 },
            new { Driver = _fixture.Drivers[3], TripCount = 1 },
            new { Driver = _fixture.Drivers[4], TripCount = 1 }
        };

        var drivers = _fixture.Trips
            .GroupBy(trip => trip.AssignedCarId)
            .Select(group => new
            {
                CarId = group.Key,
                TripCount = group.Count()
            })
            .Join(_fixture.Drivers,
                  carGroup => carGroup.CarId,
                  driver => driver.AssignedCarId,
                  (carGroup, driver) => new
                  {
                      Driver = driver,
                      carGroup.TripCount
                  })
            .OrderByDescending(d => d.TripCount)
            .Take(5)
            .ToList();

        Assert.Equal(expectedData, drivers);
    }
    /// <summary>
    /// Выводит информацию о количестве поездок, среднем времени и максимальном времени поездки для каждого водителя
    /// </summary>
    [Fact]
    public void ReturnStatisticTime()
    {
        var expectedData = new[]
        {
            new {Driver = _fixture.Drivers[0], TripCount = 2, AvgDrivingTime = new TimeOnly(0, 25, 00), MaxDrivingTime = new TimeOnly(0, 30, 0)},
            new {Driver = _fixture.Drivers[1], TripCount = 2, AvgDrivingTime = new TimeOnly(0, 55, 0), MaxDrivingTime = new TimeOnly(1, 0, 0)},
            new {Driver = _fixture.Drivers[2], TripCount = 2, AvgDrivingTime = new TimeOnly(0, 12, 30), MaxDrivingTime = new TimeOnly(0, 20, 0)},
            new {Driver = _fixture.Drivers[3], TripCount = 1, AvgDrivingTime = new TimeOnly(0, 45, 40), MaxDrivingTime = new TimeOnly(0, 45, 40)},
            new {Driver = _fixture.Drivers[4], TripCount = 1, AvgDrivingTime = new TimeOnly(0, 18, 43), MaxDrivingTime = new TimeOnly(0, 18, 43)},
            new {Driver = _fixture.Drivers[5], TripCount = 1, AvgDrivingTime = new TimeOnly(0, 23, 13), MaxDrivingTime = new TimeOnly(0, 23, 13)},
            new {Driver = _fixture.Drivers[6], TripCount = 1, AvgDrivingTime = new TimeOnly(0, 27, 47), MaxDrivingTime = new TimeOnly(0, 27, 47)},
        };

        var drivers = _fixture.Trips
            .GroupBy(trip => trip.AssignedCarId)
            .Select(group => new
            {
                CarId = group.Key,
                TripCount = group.Count(),

                AvgDrivingTime = TimeOnly.FromTimeSpan(TimeSpan.FromTicks(
                    (long)group
                        .Select(t => t.DrivingTime.ToTimeSpan().Ticks)
                        .DefaultIfEmpty(0)
                        .Average()
                )),

                MaxDrivingTime = TimeOnly.FromTimeSpan(group.Max(t => t.DrivingTime.ToTimeSpan()))
            })
            .Join(_fixture.Drivers,
                  carGroup => carGroup.CarId,
                  driver => driver.AssignedCarId,
                  (carGroup, driver) => new
                  {
                      Driver = driver,
                      carGroup.TripCount,
                      carGroup.AvgDrivingTime,
                      carGroup.MaxDrivingTime
                  })
            .ToList();

        Assert.Equal(expectedData, drivers);
    }
    /// <summary>
    /// Выводит информацию о пассажирах, совершивших максимальное число поездок за указанный период 
    /// </summary>
    [Fact]
    public void ReturnClientsMaxTrips()
    {
        var expectedData = new List<User>
        {
            _fixture.Users[0]
        };

        var startDate = new DateTime(2024, 1, 1);
        var endDate = new DateTime(2024, 12, 31);

        var trips = _fixture.Trips
            .Where(t => t.Date >= startDate && t.Date <= endDate)
            .GroupBy(t => t.AssignedUserId)
            .Select(group => new
            {
                Client = _fixture.Users.First(c => c.UserId == group.Key),
                TripCount = group.Count()
            })
            .ToList();
        var maxTripCount = trips.Max(c => c.TripCount);
        var clients = trips
            .Where(c => c.TripCount == maxTripCount)
            .Select(c => c.Client)
            .ToList();

        Assert.Equal(expectedData, clients);
    }
}
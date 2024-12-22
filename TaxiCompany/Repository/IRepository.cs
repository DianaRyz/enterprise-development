using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaxiCompany.Domain.Repository;
public interface IRepository
{
    public IEnumerable<Car> GetCars();
    public Car? GetCar(int id);
    public int PostCar(Car car);
    public bool PutCar(int id, Car car);
    public bool DeleteCar(int id);

    public IEnumerable<Driver> GetDrivers();
    public Driver? GetDriver(int id);
    public int PostDriver(Driver driver);
    public bool PutDriver(int id, Driver driver);
    public bool DeleteDriver(int id);

    public IEnumerable<Trip> GetTrips();
    public Trip? GetTrip(int id);
    public int PostTrip(Trip trip);
    public bool PutTrip(int id, Trip trip);
    public bool DeleteTrip(int id);

    public IEnumerable<User> GetUsers();
    public User? GetUser(int id);
    public int PostUser(User user);
    public bool PutUser(int id, User user);
    public bool DeleteUser(int id);
}

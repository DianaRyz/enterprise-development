using TaxiCompany.Domain;

namespace TaxiCompany.Tests;

public class TaxiCompanyFixture
{
    public List<Car> Cars =
    [
        new() {CarId = 1, Colour = "Blue", Model = "Ford", StateNumber = "272", AssignedDriverId = 1},
        new() {CarId = 2, Colour = "Green", Model = "Audi", StateNumber = "378", AssignedDriverId = 2},
        new() {CarId = 3, Colour = "Red", Model = "Nissan", StateNumber = "444", AssignedDriverId = 3},
        new() {CarId = 4, Colour = "Purple", Model = "Chevrolet", StateNumber = "555", AssignedDriverId = 4},
        new() {CarId = 5, Colour = "Orange", Model = "Peugeot", StateNumber = "689", AssignedDriverId = 5},
        new() {CarId = 6, Colour = "Silver", Model = "Mercedes", StateNumber = "412", AssignedDriverId = 6},
        new() {CarId = 7, Colour = "Gray", Model = "Subaru", StateNumber = "865", AssignedDriverId = 7}

    ];

    public List<User> Users =
    [
        new() {UserId = 1, FullName = "Ivanov Alexey Viktorovich", PhoneNumber = "89225530001"},
        new() {UserId = 2, FullName = "Petrova Maria Sergeevna", PhoneNumber = "89225530002"},
        new() {UserId = 3, FullName = "Sidorov Dmitry Alexandrovich", PhoneNumber = "89225530003"},
        new() {UserId = 4, FullName = "Kuznetsova Anna Ivanovna", PhoneNumber = "89225530004"},
        new() {UserId = 5, FullName = "Smirnov Andrey Petrovich", PhoneNumber = "89225530005"},
        new() {UserId = 6, FullName = "Popov Sergey Vasilyevich", PhoneNumber = "89225530006"},
        new() {UserId = 7, FullName = "Romanova Elena Dmitrievna", PhoneNumber = "89225530007"},
        new() {UserId = 8, FullName = "Dmitriev Igor Olegovich", PhoneNumber = "89225530008"},
        new() {UserId = 9, FullName = "Nikolaev Pavel Sergeevich", PhoneNumber = "89225530009"},
        new() {UserId = 10, FullName = "Vasilieva Natalia Alexandrovna", PhoneNumber = "89225530010"}

    ];

    public List<Driver> Drivers =
    [
        new() {DriverId = 1, FullName = "Koval Anton Sergeevich", PhoneNumber = "89167894545", Passport = "1220 451278", Address = "Lenina 12, Samara", AssignedCarId = 1},
        new() {DriverId = 2, FullName = "Pavlova Sofia Dmitrievna", PhoneNumber = "89167894546", Passport = "6310 123456", Address = "Mira 113, Tolyatti", AssignedCarId = 2},
        new() {DriverId = 3, FullName = "Karasev Vladimir Ivanovich", PhoneNumber = "89167895555", Passport = "5621 723145", Address = "Gagarina 8, Syzran", AssignedCarId = 3},
        new() {DriverId = 4, FullName = "Makarov Ilya Andreevich", PhoneNumber = "89167895556", Passport = "5608 374569", Address = "Salavat Yulaev 110, Ufa", AssignedCarId = 4},
        new() {DriverId = 5, FullName = "Frolov Roman Nikitich", PhoneNumber = "89167892525", Passport = "7815 485867", Address = "Suvorova 10, Yekaterinburg", AssignedCarId = 5},
        new() {DriverId = 6, FullName = "Lapin Ivan Romanovich", PhoneNumber = "89167896565", Passport = "6702 576178", Address = "Tverskaya 22, Moscow", AssignedCarId = 6},
        new() {DriverId = 7, FullName = "Petrov Artem Alexandrovich", PhoneNumber = "89167892524", Passport = "6409 678119", Address = "Nevsky 74, Saint Petersburg", AssignedCarId = 7}
    ];

    public List<Trip> Trips =
    [
        new() {TripId = 1, Departure = "Lenina 12", Destination = "Pobedy 10", Date = new DateTime(2024, 1, 15), DrivingTime = new TimeOnly(0, 20, 0), Cost = 235, AssignedUserId = 1, AssignedCarId = 1},
        new() {TripId = 2, Departure = "Moskovskaya 67", Destination = "Zvezdnaya 56", Date = new DateTime(2024, 2, 23), DrivingTime = new TimeOnly(1, 0, 0), Cost = 1000, AssignedUserId = 2, AssignedCarId = 2},
        new() {TripId = 3, Departure = "Maslennikova 90", Destination = "Samarskaya 101", Date = new DateTime(2024, 3, 8), DrivingTime = new TimeOnly(0, 5, 0), Cost = 98, AssignedUserId = 3, AssignedCarId = 3},
        new() {TripId = 4, Departure = "Arbat 68", Destination = "Tverskaya 13", Date = new DateTime(2024, 4, 5), DrivingTime = new TimeOnly(0, 45, 40), Cost = 741, AssignedUserId = 4, AssignedCarId = 4},
        new() {TripId = 5, Departure = "Ohotnaya 30", Destination = "Lenina 74", Date = new DateTime(2024, 5, 22), DrivingTime = new TimeOnly(0, 18, 43), Cost = 163, AssignedUserId = 5, AssignedCarId = 5},
        new() {TripId = 6, Departure = "Gagarina 99", Destination = "Nevsky 89", Date = new DateTime(2024, 6, 11), DrivingTime = new TimeOnly(0, 23, 13), Cost = 220, AssignedUserId = 6, AssignedCarId = 6},
        new() {TripId = 7, Departure = "Rossa 452", Destination = "Marta 8", Date = new DateTime(2024, 8, 8), DrivingTime = new TimeOnly(0, 27, 47), Cost = 289, AssignedUserId = 7, AssignedCarId = 7},
        new() {TripId = 8, Departure = "Lenina 82", Destination = "Vilonova 91", Date = new DateTime(2024, 10, 9), DrivingTime = new TimeOnly(0, 30, 0), Cost = 465, AssignedUserId = 8, AssignedCarId = 1},
        new() {TripId = 9, Departure = "Mira 96", Destination = "Popova 32", Date = new DateTime(2024, 11, 11), DrivingTime = new TimeOnly(0, 50, 0), Cost = 302, AssignedUserId = 9, AssignedCarId = 2},
        new() {TripId = 10, Departure = "Rabochaya 4", Destination = "Moskovskaya 1", Date = new DateTime(2024, 12, 24), DrivingTime = new TimeOnly(0, 20, 0), Cost = 284, AssignedUserId = 1, AssignedCarId = 3}
    ];
}

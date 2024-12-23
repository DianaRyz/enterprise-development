using TaxiCompany.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace TaxiCompany.Domain;
/// <summary>
/// Контекст базы данных для таксопарка
/// </summary>
public class TaxiCompanyContext(DbContextOptions<TaxiCompanyContext> options) : DbContext(options)
{
    /// <summary>
    /// Таблица автомобилей
    /// </summary>
    public DbSet<Car> Cars { get; set; }

    /// <summary>
    /// Таблица водителей
    /// </summary>
    public DbSet<Driver> Drivers { get; set; }

    /// <summary>
    /// Таблица поездок
    /// </summary>
    public DbSet<Trip> Trips { get; set; }

    /// <summary>
    /// Таблица клиентов
    /// </summary>
    public DbSet<User> Users { get; set; }

    /// <summary>
    /// Переопределение метода для установления отношений между таблицами
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>()
            .HasOne<Driver>()  
            .WithMany()        
            .HasForeignKey(c => c.AssignedDriverId)  
            .OnDelete(DeleteBehavior.Restrict); 

        modelBuilder.Entity<Driver>()
            .HasOne<Car>()  
            .WithMany()
            .HasForeignKey(d => d.AssignedCarId)  
            .OnDelete(DeleteBehavior.Restrict);  

        
        modelBuilder.Entity<Car>()
            .HasMany<Trip>()  
            .WithOne()         
            .HasForeignKey(t => t.AssignedCarId)  
            .OnDelete(DeleteBehavior.Restrict);  

        
        modelBuilder.Entity<User>()
            .HasMany<Trip>()  
            .WithOne()         
            .HasForeignKey(t => t.AssignedUserId)  
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Car>()
            .HasIndex(c => c.StateNumber)
            .IsUnique();

        modelBuilder.Entity<Driver>()
            .HasIndex(d => d.Passport)
            .IsUnique();
    }
}

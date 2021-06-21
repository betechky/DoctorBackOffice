using System;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

public class AppDbContext : DbContext
{
    public DbSet<Doctor> Doctors { set; get; }
    public DbSet<Patient> Patients { set; get; }
    public DbSet<IntakeForm> IntakeForms { set; get; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(@"server=localhost;user=root;password=Nicoledino09;database=DoctorsOffice",
            ServerVersion.Parse("5.7.34-mysql")
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Doctor>().HasData(
              new Doctor{
                  Id=1, 
                  Name="Dr. Jason Rivera"
              },
              new Doctor{
                  Id=2, 
                  Name="Dr. Michelle Tayson"
              },
              new Doctor{
                  Id=3, 
                  Name="Dr. Leonor Rodrigo"
              }
        );

         modelBuilder.Entity<Patient>().HasData(
              new Patient
              {
                  Id=1, 
                  HealthNumber=12301,
                  Name="Marjorie Bautosa",
                  Address ="154, Ambertrail Winnipeg", 
                  DateofBirth = new DateTime(1997, 02, 12),
                  PhoneNumber="204 223-4567"
              },
                new Patient
              {
                  Id=2, 
                  HealthNumber=12402,
                  Name="Stephanie Letter",
                  Address ="11, Ambertrail Winnipeg", 
                  DateofBirth = new DateTime(2009, 09, 09),
                  PhoneNumber="204 999999"
            }
        );              
    }
}
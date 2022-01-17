using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial1.Models;

namespace Tutorial1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Patient>()
        //        .HasOne(b => b.Appointment)
        //        .WithOne(i => i.Patient)
        //        .HasForeignKey<Appointment>(b => b.PatientId);

        //    modelBuilder.Entity<Doctor>()
        //        .HasOne(b => b.Appointment)
        //        .WithOne(i => i.Doctor)
        //        .HasForeignKey<Appointment>(b => b.DoctorId);
        //}
    }
}

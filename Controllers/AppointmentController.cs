using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial1.Data;
using Tutorial1.Models;


namespace Tutorial1.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly AppDbContext _db;

        public AppointmentController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Create()
        {
            AppointmentViewModel model = new AppointmentViewModel();
            model.appointment = new Appointment();
            model.appointments = _db.Appointments.ToList();
            model.doctors = new SelectList(_db.Doctors, "Id", "Name");
            model.patients = new SelectList(_db.Patients, "Id", "Name");

            foreach (var visit in model.appointments)
            {
                visit.PatientName = _db.Patients.Where(x => x.Id == visit.PatientId).Select(x => x.Name).FirstOrDefault();
                visit.DoctorName = _db.Doctors.Where(x => x.Id == visit.DoctorId).Select(x => x.Name).FirstOrDefault();
            }

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AppointmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                Appointment app = new Appointment();
                app.PatientId = Convert.ToInt32(model.PatientId);
                app.Complaints = model.Complaints;
                app.DoctorId = Convert.ToInt32(model.DoctorId);
                app.Diagnose = model.Diagnose;
                app.DateOfVisit = model.DateOfVisit;
                _db.Appointments.Add(app);
                _db.SaveChanges();
                return View();
            }
            else
            {
                AppointmentViewModel models = new AppointmentViewModel();
                Appointment app = new Appointment();
                app.PatientId = Convert.ToInt32(model.PatientId);
                app.Complaints = model.Complaints;
                app.DoctorId = Convert.ToInt32(model.DoctorId);
                app.Diagnose = model.Diagnose;
                app.DateOfVisit = model.DateOfVisit;
                models.appointment = app;
                models.appointments = _db.Appointments.ToList();
                models.doctors = new SelectList(_db.Doctors, "Id", "Name");
                models.patients = new SelectList(_db.Patients, "Id", "Name");

                foreach (var visit in models.appointments)
                {
                    visit.PatientName = _db.Patients.Where(x => x.Id == visit.PatientId).Select(x => x.Name).FirstOrDefault();
                    visit.DoctorName = _db.Doctors.Where(x => x.Id == visit.DoctorId).Select(x => x.Name).FirstOrDefault();
                }
                ModelState.AddModelError("ReviewErrors", "some error occured");
                return View(models);
            }
        }

        public IActionResult Delete(int id)
        {
            var appointment = _db.Appointments.Where(x => x.Id == id).FirstOrDefault();
            _db.Appointments.Remove(appointment);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tutorial1.Data;
using Tutorial1.Models;

namespace Tutorial1.Controllers
{
    public class PatientController : Controller
    {
        private readonly AppDbContext _db;

        public PatientController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Create()
        {
            PatientViewModel model = new PatientViewModel();
            model.patient = new Patient();
            model.patients = _db.Patients.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Patient patient)
        {
            if (ModelState.IsValid)
            {
                _db.Patients.Add(patient);
                _db.SaveChanges();
                return View();
            }
            else
            {
                ModelState.AddModelError("ReviewErrors", "some error occured");
                PatientViewModel model = new PatientViewModel();
                model.patient = patient;
                model.patients = _db.Patients.ToList();
                return View(model);
            }
        }

        public IActionResult Delete(int id)
        {
            var patient = _db.Patients.Where(x => x.Id == id).FirstOrDefault();
            _db.Patients.Remove(patient);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }
    }
}

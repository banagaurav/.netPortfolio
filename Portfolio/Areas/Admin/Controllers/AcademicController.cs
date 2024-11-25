using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class AcademicController : Controller
    {
        private readonly AppDbContext _db;
        public AcademicController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Academic> objAcademicList = _db.Academics.ToList();
            return View(objAcademicList);
        }
        public IActionResult AcademicDetails(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Academic academicFromDb = _db.Academics.Find(id);
            if (academicFromDb == null)
            {
                return NotFound();
            }
            return View(academicFromDb);
        }

        //Edit AcademicPage
        public IActionResult EditBand()
        {
            List<Academic> objAcademicList = _db.Academics.ToList();
            return View(objAcademicList);
        }

        // Add/Create/Post Academic

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Academic obj)
        {
            if (ModelState.IsValid)
            {
                _db.Academics.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("EditAcademic"); // for different controller ("action","Controller")
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Academic academicFromDb = _db.Academics.Find(id);
            if (academicFromDb == null)
            {
                return NotFound();
            }
            return View(academicFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Academic obj)
        {
            if (ModelState.IsValid)
            {
                _db.Academics.Update(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("EditAcademic"); // for different controller ("action","Controller")
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Academic academicFromDb = _db.Academics.Find(id);
            if (academicFromDb == null)
            {
                return NotFound();
            }
            return View(academicFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Academic? obj = _db.Academics.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Academics.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("EditAcademic"); // for different controller ("action","Controller")
        }
    }
}

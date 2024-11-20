using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Controllers
{
    public class BandController : Controller
    {
        private readonly AppDbContext _db;
        public BandController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Band> objBandList = _db.Bands.ToList();
            return View(objBandList);
        }

        //Edit BlogPage
        public IActionResult EditBand()
        {
            List<Band> objBandList = _db.Bands.ToList();
            return View(objBandList);
        }

        // Add/Create/Post Band

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Band obj)
        {
            if (ModelState.IsValid)
            {
                _db.Bands.Add(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("EditBand"); // for different controller ("action","Controller")
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Band bandFromDb = _db.Bands.Find(id);
            if (bandFromDb == null)
            {
                return NotFound();
            }
            return View(bandFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Band obj)
        {
            if (ModelState.IsValid)
            {
                _db.Bands.Update(obj);
                _db.SaveChanges();
            }
            return RedirectToAction("EditBand"); // for different controller ("action","Controller")
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Band bandFromDb = _db.Bands.Find(id);
            if (bandFromDb == null)
            {
                return NotFound();
            }
            return View(bandFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Band? obj = _db.Bands.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Bands.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("EditBand"); // for different controller ("action","Controller")
        }
    }
}

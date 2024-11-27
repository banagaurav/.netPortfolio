using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]

    public partial class BandController : Controller
    {
        private readonly AppDbContext _db;
        public BandController(AppDbContext db)
        {
            _db = db;
        }



        //Edit BandPage
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
        [ValidateAntiForgeryToken]
        public IActionResult Create(Band obj)
        {
            if (ModelState.IsValid)
            {
                // Add the band record to the database
                _db.Bands.Add(obj);
                _db.SaveChanges(); // Save to generate BandId for the new band

                // Check if the Image URL is provided
                if (!string.IsNullOrEmpty(obj.Image))
                {
                    // Create a new Photo record associated with the band
                    var photo = new Photo
                    {
                        FilePath = obj.Image, // Save the image URL
                        UploadTime = DateTime.Now,
                        BandId = obj.BandId, // Associate with the newly created band
                        DisplayOrder = obj.DisplayOrder // Use the same display order if needed
                    };

                    // Add the photo record to the database
                    _db.Photos.Add(photo);
                    _db.SaveChanges();
                }

                return RedirectToAction("EditBand", "Band"); // Redirect to another action in the Band controller
            }

            return View(obj); // Return the same view if the model state is invalid
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

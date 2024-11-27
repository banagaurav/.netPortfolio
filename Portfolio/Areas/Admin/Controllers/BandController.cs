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
                        DisplayOrder = obj.DisplayOrder, // Use the same display order if needed
                        Category = "Band" // Set category as "Band"
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
                // Update the band record in the database
                _db.Bands.Update(obj);
                _db.SaveChanges();

                // Check if the Image URL is provided
                if (!string.IsNullOrEmpty(obj.Image))
                {
                    // Check if a photo associated with this Band already exists
                    var existingPhoto = _db.Photos.FirstOrDefault(p => p.BandId == obj.BandId);

                    if (existingPhoto != null)
                    {
                        // Update the existing Photo record
                        existingPhoto.FilePath = obj.Image; // Update the image URL
                        existingPhoto.UploadTime = DateTime.Now; // Update the upload time
                        existingPhoto.DisplayOrder = obj.DisplayOrder; // Update display order
                        existingPhoto.Category = "Band"; // Ensure category is "Band"
                        _db.Photos.Update(existingPhoto);
                    }
                    else
                    {
                        // Create a new Photo record if none exists
                        var newPhoto = new Photo
                        {
                            FilePath = obj.Image, // Save the new image URL
                            UploadTime = DateTime.Now,
                            BandId = obj.BandId, // Associate with the band
                            DisplayOrder = obj.DisplayOrder, // Use the band's display order
                            Category = "Band" // Set category as "Band"
                        };
                        _db.Photos.Add(newPhoto);
                    }

                    _db.SaveChanges(); // Save changes to the database
                }

                return RedirectToAction("EditBand"); // Redirect to the EditBand action
            }

            return View(obj); // Return the same view if the model state is invalid
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

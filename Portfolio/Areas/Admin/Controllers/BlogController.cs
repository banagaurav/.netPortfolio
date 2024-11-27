using Microsoft.AspNetCore.Mvc;
using Portfolio.Data;
using Portfolio.Models;

namespace Portfolio.Areas.Admin.Controllers
{
    [Area("Admin")]

    public partial class BlogController : Controller
    {
        private readonly AppDbContext _db;
        public BlogController(AppDbContext db)
        {
            _db = db;
        }



        //Edit BlogPage
        public IActionResult EditBlog()
        {
            List<Blog> objBlogList = _db.Blogs.ToList();
            return View(objBlogList);
        }

        // Add/Create/Post blog

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog obj)
        {
            if (ModelState.IsValid)
            {
                // Add the blog record to the database
                _db.Blogs.Add(obj);
                _db.SaveChanges(); // Save to generate BlogId for the new blog

                // Check if the Image URL is provided
                if (!string.IsNullOrEmpty(obj.Image))
                {
                    // Create a new Photo record associated with the blog
                    var photo = new Photo
                    {
                        FilePath = obj.Image, // Save the image URL
                        UploadTime = DateTime.Now,
                        BlogId = obj.BlogId, // Associate with the newly created blog
                        DisplayOrder = obj.DisplayOrder, // Use the same display order if needed
                        Category = "Blog" // Set category as "Blog"
                    };

                    // Add the photo record to the database
                    _db.Photos.Add(photo);
                    _db.SaveChanges();
                }

                return RedirectToAction("EditBlog", "Blog"); // Redirect to another action in the Blog controller
            }

            return View(obj); // Return the same view if the model state is invalid
        }



        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Blog blogFromDb = _db.Blogs.Find(id);
            if (blogFromDb == null)
            {
                return NotFound();
            }
            return View(blogFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Blog obj)
        {
            if (ModelState.IsValid)
            {
                // Update the blog record in the database
                _db.Blogs.Update(obj);
                _db.SaveChanges();

                // Check if the Image URL is provided
                if (!string.IsNullOrEmpty(obj.Image))
                {
                    // Check if a photo associated with this Blog already exists
                    var existingPhoto = _db.Photos.FirstOrDefault(p => p.BlogId == obj.BlogId);

                    if (existingPhoto != null)
                    {
                        // Update the existing Photo record
                        existingPhoto.FilePath = obj.Image; // Update the image URL
                        existingPhoto.UploadTime = DateTime.Now; // Update the upload time
                        existingPhoto.DisplayOrder = obj.DisplayOrder; // Update display order
                        existingPhoto.Category = "Blog"; // Ensure category is "Blog"
                        _db.Photos.Update(existingPhoto);
                    }
                    else
                    {
                        // Create a new Photo record if none exists
                        var newPhoto = new Photo
                        {
                            FilePath = obj.Image, // Save the new image URL
                            UploadTime = DateTime.Now,
                            BlogId = obj.BlogId, // Associate with the blog
                            DisplayOrder = obj.DisplayOrder, // Use the blog's display order
                            Category = "Blog" // Set category as "Blog"
                        };
                        _db.Photos.Add(newPhoto);
                    }

                    _db.SaveChanges(); // Save changes to the database
                }

                return RedirectToAction("EditBlog"); // Redirect to the EditBlog action
            }

            return View(obj); // Return the same view if the model state is invalid
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Blog blogFromDb = _db.Blogs.Find(id);
            if (blogFromDb == null)
            {
                return NotFound();
            }
            return View(blogFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Blog? obj = _db.Blogs.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Blogs.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("EditBlog"); // for different controller ("action","Controller")
        }
    }
}

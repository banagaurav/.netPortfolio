using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Portfolio.Controllers;
public class AlbumController
{
    public IActionResult Index()
    {
        return View();
    }
}

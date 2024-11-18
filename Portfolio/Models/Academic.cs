using System;

namespace Portfolio.Models;

public class Academic
{
    public int AcademicId { get; set; }
    public string Title { get; set; }
    public string Image { get; set; } //PDF
    public string AcaDescription { get; set; }
    public int DisplayOrder { get; set; }
}

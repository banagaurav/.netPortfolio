using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class Academic
{
    [Key]
    public int AcademicId { get; set; }
    public string Title { get; set; }
    public string Image { get; set; } //PDF
    public string Description { get; set; }
    public int DisplayOrder { get; set; }
}

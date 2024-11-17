using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class Photo
{
    [Key]
    public int PhotoId { get; set; }
    public string? Caption { get; set; }
    public string Category { get; set; }
    public string Image { get; set; }
    public DateTime UploadTime { get; set; } = DateTime.Now;
    public int DisplayOrder { get; set; }
}

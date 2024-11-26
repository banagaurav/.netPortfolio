using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models;

public class Photo
{
    [Key]
    public int PhotoId { get; set; }

    public DateTime UploadTime { get; set; } = DateTime.Now;

    public int DisplayOrder { get; set; }

    public string FilePath { get; set; } // URL or file path of the photo

    // Foreign Key to Blog
    public int? BlogId { get; set; }

    [ForeignKey("BlogId")]
    public Blog Blog { get; set; } // Navigation property
}
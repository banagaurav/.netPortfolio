using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class Album
{
    [Key]
    public int AlbumId { get; set; }
    public string Image { get; set; }
    public string Category { get; set; }
    public DateTime UploadTime { get; set; }
    public int DisplayOrder { get; set; }
}

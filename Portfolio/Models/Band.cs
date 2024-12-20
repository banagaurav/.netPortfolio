using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class Band
{
    [Key]
    public int BandId { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }
    public string Description { get; set; }
    public int DisplayOrder { get; set; }

}

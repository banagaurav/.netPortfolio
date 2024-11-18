using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class Project
{
    [Key]
    public int ProjectId { get; set; }

    public string Title { get; set; }

    public string Link { get; set; }

    public string Image { get; set; }

    public string Description { get; set; }

    public int DisplayOrder { get; set; }
}

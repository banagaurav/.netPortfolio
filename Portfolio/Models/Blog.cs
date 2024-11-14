

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models;

public class Blog
{
    [Key]
    public int BlogId { get; set; }
    [DisplayName("Blog Title")]
    public string Title { get; set; }
    [DisplayName("Sub-image")]
    public string Image { get; set; }
    [DisplayName("Description")]
    public string textarea { get; set; }
}

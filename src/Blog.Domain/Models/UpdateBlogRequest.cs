using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Models;

public class UpdateBlogRequest
{
    [Required]
    public int BlogId { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public DateTime UpdateDate = DateTime.Now;
}
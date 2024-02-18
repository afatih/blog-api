using System.ComponentModel.DataAnnotations;

namespace Blog.Domain.Models;

public class CreateBlogRequest
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }
    
    public DateTime CreateDate = DateTime.Now;
    
    public int UserId { get; set; }
}
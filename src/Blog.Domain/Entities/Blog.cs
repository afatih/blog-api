namespace Blog.Domain.Entities;

public class Blog
{
    public int BlogId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int UserId { get; set; }
}
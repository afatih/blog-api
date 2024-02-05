namespace Blog.Domain.Interfaces.Services;

using Blog.Domain.Entities;

public interface IBlogService
{
    Task<IEnumerable<Blog>> GetAll();
}
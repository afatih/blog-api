namespace Blog.Domain.Interfaces.Repositories;

using Blog.Domain.Entities;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetAll();
    Task<bool> Create(Blog blog);
}
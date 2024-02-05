namespace Blog.Domain.Interfaces.Repositories;

using Blog.Domain.Entities;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> GetAll();
}
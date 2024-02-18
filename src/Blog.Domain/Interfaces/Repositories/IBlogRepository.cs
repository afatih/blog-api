namespace Blog.Domain.Interfaces.Repositories;

using Blog.Domain.Entities;

public interface IBlogRepository
{
    Task<IEnumerable<Blog>> Get(int? blogId);
    Task<bool> Create(Blog blog);
    Task<bool> Delete(int blogId);
    Task<Blog> Update(Blog blog);
}
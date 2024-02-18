using Blog.Domain.Models;

namespace Blog.Domain.Interfaces.Services;

using Entities;

public interface IBlogService
{
    Task<IEnumerable<Blog>> GetAll();
    Task<bool> Create(CreateBlogRequest blog);
}
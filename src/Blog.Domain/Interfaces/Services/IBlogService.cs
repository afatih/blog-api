using Blog.Domain.Models;

namespace Blog.Domain.Interfaces.Services;

using Entities;

public interface IBlogService
{
    Task<IEnumerable<Blog>> Get(int? blogId);
    Task<bool> Create(CreateBlogRequest blog);
    Task<bool> Delete(int blogId);
    Task<Blog> Update(UpdateBlogRequest blog);

}
using Blog.Domain.Interfaces.Repositories;
using Blog.Domain.Interfaces.Services;
using Blog.Domain.Models;
using Mapster;

namespace Blog.Application.Services.Implementations;

public class BlogService(IBlogRepository blogRepository) : IBlogService
{
    public async Task<IEnumerable<Domain.Entities.Blog>> Get(int? blogId)
    {
        var blogs = blogRepository.Get(blogId);

        return await blogs;
    }

    public async Task<bool> Create(CreateBlogRequest blog)
    {
        var result = blogRepository.Create(blog.Adapt<Domain.Entities.Blog>());
        return await result;
    }

    public async Task<bool> Delete(int blogId)
    {
        var result = blogRepository.Delete(blogId);
        return await result;
    }

    public async Task<Domain.Entities.Blog> Update(UpdateBlogRequest blog)
    {
        var result = blogRepository.Update(blog.Adapt<Domain.Entities.Blog>());
        return await result;
    }
}
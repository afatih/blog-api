using Blog.Domain.Interfaces.Repositories;
using Blog.Domain.Interfaces.Services;
using Blog.Domain.Models;
using Blog.Domain.Models.Dto;
using Mapster;

namespace Blog.Application.Services.Implementations;

public class BlogService(IBlogRepository blogRepository) : IBlogService
{
    public async Task<IEnumerable<BlogDto>> GetAll(string title)
    {
        var blogs = blogRepository.GetAll(title);

        return await blogs;
    }

    public async Task<BlogDto> GetDetail(int blogId)
    {
        var blog = blogRepository.GetDetail(blogId);

        return await blog;
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
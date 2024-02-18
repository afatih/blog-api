using Blog.Domain.Interfaces.Repositories;
using Blog.Domain.Interfaces.Services;
using Blog.Domain.Models;
using Mapster;

namespace Blog.Application.Services.Implementations;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;

    public BlogService(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    
    public async Task<IEnumerable<Domain.Entities.Blog>> GetAll()
    {
        var blogs = _blogRepository.GetAll();

        return await blogs;
    }

    public async Task<bool> Create(CreateBlogRequest blog)
    {
        var result = _blogRepository.Create(blog.Adapt<Domain.Entities.Blog>());
        return await result;
    }
}
using Blog.Domain.Interfaces.Repositories;
using Blog.Domain.Interfaces.Services;

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
}
using Blog.Domain.Interfaces.Services;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService;

    public BlogController(IBlogService blogService)
    {
        _blogService = blogService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var blogs = await _blogService.GetAll();
        return Ok(blogs);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateBlogRequest request)
    {
        var blog = await _blogService.Create(request); 
        return Created( string.Empty, blog);
    }
}
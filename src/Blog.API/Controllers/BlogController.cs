using Blog.Domain.Interfaces.Services;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogController(IBlogService blogService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? blogId)
    {
        var blogs = await blogService.Get(blogId);
        return Ok(blogs);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBlogRequest request)
    {
        var blog = await blogService.Create(request);
        if (!blog)
        {
            return BadRequest();
        }
        return Created( string.Empty, blog);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] int blogId)
    {
        var result = await blogService.Delete(blogId);
        if (!result)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBlogRequest request)
    {
        var blog = await blogService.Update(request);
        if (blog is null)
        {
            return BadRequest();
        }
        return Ok(blog);
    }
}
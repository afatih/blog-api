using Blog.Domain.Interfaces.Services;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers;

[ApiController()]
public class BlogController(IBlogService blogService) : ControllerBase
{
    [HttpGet("blogs")]
    public async Task<IActionResult> GetAll([FromQuery] string? title)
    {
        var blogs = await blogService.GetAll(title);
        if (blogs is null)
        {
            return NotFound();
        }
        return Ok(blogs);
    }
    
    [HttpGet("blog/{blogId}")]
    public async Task<IActionResult> GetDetail(int blogId)
    {
        var blog = await blogService.GetDetail(blogId);
        if (blog is null)
        {
            return NotFound();
        }
        return Ok(blog);
    }

    [HttpPost("blog")]
    public async Task<IActionResult> Create([FromBody] CreateBlogRequest request)
    {
        var blog = await blogService.Create(request);
        if (!blog)
        {
            return BadRequest();
        }
        return Created( string.Empty, blog);
    }

    [HttpDelete("blog")]
    public async Task<IActionResult> Delete([FromBody] int blogId)
    {
        var result = await blogService.Delete(blogId);
        if (!result)
        {
            return BadRequest();
        }
        return Ok();
    }

    [HttpPut("blog")]
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
using Blog.Domain.Models;
using Blog.Domain.Models.Dto;

namespace Blog.Domain.Interfaces.Services;

using Entities;

public interface IBlogService
{
    Task<IEnumerable<BlogDto>> GetAll(string title);
    Task<BlogDto> GetDetail(int blogId);
    Task<bool> Create(CreateBlogRequest blog);
    Task<bool> Delete(int blogId);
    Task<Blog> Update(UpdateBlogRequest blog);

}
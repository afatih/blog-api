using Blog.Domain.Models.Dto;

namespace Blog.Domain.Interfaces.Repositories;

using Blog.Domain.Entities;

public interface IBlogRepository
{
    Task<IEnumerable<BlogDto>> GetAll(string title);
    Task<BlogDto> GetDetail(int blogId);
    Task<bool> Create(Blog blog);
    Task<bool> Delete(int blogId);
    Task<Blog> Update(Blog blog);
}
using Blog.Domain.Interfaces.Repositories;
using Blog.Domain.Models.Dto;
using Dapper;

namespace Blog.Infrastructure.Repositories;

using Domain.Entities;

public class BlogRepository(DataContext context) : IBlogRepository
{
    public async Task<IEnumerable<BlogDto>> GetAll(string title)
    {
        using var connection = context.CreateConnection();
        var titleFilter = !string.IsNullOrEmpty(title) ? $"where Title like '%{title}%'" : string.Empty;
        var sql = $"""
                  SELECT * FROM Blog b 
                  inner join User u on b.UserId = u.UserId 
                  {titleFilter} 
                  order by BlogId desc
                  """;
        return await connection.QueryAsync<BlogDto>(sql);
    }
    
    public async Task<BlogDto> GetDetail(int blogId)
    {
        using var connection = context.CreateConnection();
        var sql = $"""
                   SELECT * FROM Blog b
                   inner join User u on b.UserId = u.UserId
                   where b.BlogId = {blogId} 
                   order by BlogId desc
                   """;
        return await connection.QueryFirstOrDefaultAsync<BlogDto>(sql);
    }

    public async Task<bool> Create(Blog blog)
    {
        using var connection = context.CreateConnection();
        var sql = @"
                INSERT INTO Blog (Title, Description, CreateDate, UpdateDate, UserId)
                VALUES (@Title, @Description, @CreateDate, @UpdateDate, @UserId);
                ";
        return await connection.ExecuteAsync(sql, blog) > 0;
    }

    public async Task<bool> Delete(int blogId)
    {
        using var connection = context.CreateConnection();
        var sql = @"delete from Blog where BlogId = @blogId";
        var parameters = new { blogId };
        return await connection.ExecuteAsync(sql, parameters) > 0;
    }

    public async Task<Blog> Update(Blog blog)
    {using var connection = context.CreateConnection();
        var sql = @"
                UPDATE Blog
                SET Title = @title, Description = @description, UpdateDate = @updateDate
                WHERE BlogId = @blogId;

                SELECT * FROM Blog WHERE BlogId = @blogId; -- Retrieve the updated row
            ";
        using var multipleQuery = await connection.QueryMultipleAsync(sql, blog);

        var updatedBlog = await multipleQuery.ReadSingleOrDefaultAsync<Blog>();

        return updatedBlog;
    }
}
using Blog.Domain.Interfaces.Repositories;
using Dapper;

namespace Blog.Infrastructure.Repositories;

using Domain.Entities;

public class BlogRepository(DataContext context) : IBlogRepository
{
    public async Task<IEnumerable<Blog>> Get(int? blogId)
    {
        using var connection = context.CreateConnection();
        var blogIdFilter = blogId is not null ? $"where blogId ={blogId}" : string.Empty;
        var sql = $"""
                  SELECT * FROM Blog {blogIdFilter} order by BlogId desc
                  """;
        return await connection.QueryAsync<Blog>(sql);
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
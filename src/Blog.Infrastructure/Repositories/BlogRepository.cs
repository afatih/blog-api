using Blog.Domain.Interfaces.Repositories;
using Dapper;

namespace Blog.Infrastructure.Repositories;

using Blog.Domain.Entities;


public class BlogRepository : IBlogRepository
{
    
    private readonly DataContext _context;

    public BlogRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Blog>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
                  SELECT * FROM Blog order by BlogId desc
                  """;
        return await connection.QueryAsync<Blog>(sql);
    }

    public async Task<bool> Create(Blog blog)
    {
        using var connection = _context.CreateConnection();
        var sql = @"
                INSERT INTO Blog (Title, Description, CreateDate, UpdateDate, UserId)
                VALUES (@Title, @Description, @CreateDate, @UpdateDate, @UserId);
                ";
        return await connection.ExecuteAsync(sql, blog) > 0;
    }
}
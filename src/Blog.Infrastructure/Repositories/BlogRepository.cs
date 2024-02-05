using Blog.Domain.Interfaces.Repositories;
using Dapper;

namespace Blog.Infrastructure.Repositories;

using Blog.Domain.Entities;


public class BlogRepository : IBlogRepository
{
    
    private DataContext _context;

    public BlogRepository(DataContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Blog>> GetAll()
    {
        using var connection = _context.CreateConnection();
        var sql = """
                      SELECT * FROM Blog
                  """;
        return await connection.QueryAsync<Blog>(sql);
    }
}
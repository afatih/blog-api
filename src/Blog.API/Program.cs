using Blog.Application.Services.Implementations;
using Blog.Domain.Interfaces.Repositories;
using Blog.Domain.Interfaces.Services;
using Blog.Infrastructure;
using Blog.Infrastructure.Repositories;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

{
    var services = builder.Services;

    services.AddCors();
    services.AddControllers();
    
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Blog API", Version = "v1" });
    });
    
    services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));

    services.AddSingleton<DataContext>();
    services.AddScoped<IBlogRepository, BlogRepository>();
    services.AddScoped<IBlogService, BlogService>();
}

var app = builder.Build();

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

    app.MapControllers();
    
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blog API v1");
        c.RoutePrefix = string.Empty;
    });
}

app.Run();
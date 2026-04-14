using Microsoft.EntityFrameworkCore;
using CollegeApi.Data;
using CollegeApi.Services;
using CollegeApi.Middleware;
using CollegeApi.Repositories;
using Scalar.AspNetCore;      


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<Database>(options =>
    options.UseInMemoryDatabase("CollegeDb"));

builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<IStudentService,    StudentService>();

builder.Services.AddOpenApi();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();
app.Run();
using Microsoft.EntityFrameworkCore;
using Yinko.Api.Infrastructure;
using Yinko.Application;
using Yinko.Application.Common.Interfaces;
using Yinko.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("Yinko.Infrastructure")
    ));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSvelte", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddScoped<IApplicationDbContext>(provider =>
    provider.GetRequiredService<AppDbContext>());

builder.Services.AddApplicationServices();

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
app.UseCors("AllowSvelte");
app.UseAuthorization();
app.MapControllers();

app.Run();
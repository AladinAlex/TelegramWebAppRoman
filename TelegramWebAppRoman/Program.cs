using Microsoft.EntityFrameworkCore;
using TelegramWebAppRoman.Contexts;
using TelegramWebAppRoman.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(builder.Configuration.GetConnectionString("DbDealer"));
builder.Services.AddServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("VuePolicy", c =>
    {
        c
            .WithOrigins(builder.Configuration.GetSection("CorsUrls").Get<string[]>())
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
            
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("VuePolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

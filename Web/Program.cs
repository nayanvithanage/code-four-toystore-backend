using Swashbuckle.AspNetCore.SwaggerGen;
using toystore_backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using toystore_backend.Core.Interfaces;
using toystore_backend.Core.Services;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

//Add api documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register db context for dependency injection
builder.Services.AddDbContext<ToyDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ToyDbConnection")));

builder.Services.AddScoped<IToyRepository, ToyRepository>();
builder.Services.AddScoped<ToyService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowAngular");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ToyDbContext>();
    dbContext.Database.Migrate();
}

app.Run();


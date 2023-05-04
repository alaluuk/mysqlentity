using Entitytest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(options =>
{
        var connectionString = System.Environment.GetEnvironmentVariable("DATABASE_URL");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
if (app.Environment.IsDevelopment()){
app.Use(async (contex, next)=>
{
    System.Environment.SetEnvironmentVariable("DATABASE_URL", "server=127.0.0.1;user id=netuser;password=netpass;port=3306;database=entitydb;");

    Console.WriteLine(System.Environment.GetEnvironmentVariable("DATABASE_URL"));
    await next();
}
);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

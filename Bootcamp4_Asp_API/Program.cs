using Bootcamp4_AspMVC.Data;
using Bootcamp4_AspMVC.Interfaces.IServices;
using Bootcamp4_AspMVC.Interfaces;
using Bootcamp4_AspMVC.Repositories;
using Bootcamp4_AspMVC.Serivces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options
.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IRepository<>), typeof(MainRepository<>));
builder.Services.AddScoped(typeof(IProductRepo), typeof(ProductRepo));
builder.Services.AddScoped(typeof(IEmployeeRepo), typeof(EmployeeRepo));
builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

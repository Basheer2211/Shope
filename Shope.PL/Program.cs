using Microsoft.EntityFrameworkCore;
using Shope.BLL.Services;
using Shope.DAL.data;
using Shope.DAL.Repository;
using Shope.DAL.Repository.Interface;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.Repository.Class;
using Shope.BLL.Services.Classes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<Irepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryServieces, Categoryservices>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandsServices, BrandsServices>();

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

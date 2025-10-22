using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Shope.BLL.Services;
using Shope.DAL.data;
using Shope.DAL.Repository;
using Shope.DAL.Repository.Interface;
using Shope.BLL.Services.Interfaces;
using Shope.DAL.Repository.Class;
using Shope.BLL.Services.Classes;
using Shope.DAL.SeedData.Interface;
using Shope.DAL.SeedData.Class;
using Microsoft.AspNetCore.Identity;
using Shope.DAL.Models;
using  Shope.PL.helper;
using Microsoft.AspNetCore.Identity.UI.Services;
using Stripe;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.SignIn.RequireConfirmedEmail = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
}).AddDefaultTokenProviders()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();


// Add services to the container.

builder.Services.AddControllers();
var userPolicy = "";
builder.Services.AddCors(option =>
{
    option.AddPolicy(name: userPolicy, policy =>
    {
        policy.AllowAnyOrigin();
    });
}

);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<Irepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryServieces, Categoryservices>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IBrandsServices, BrandsServices>();
builder.Services.AddScoped<IAuthenticationServices, AutenticationServices>();
builder.Services.AddScoped<ISeedData, SeedData>();
builder.Services.AddScoped<IorderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IFileservieces, FileServieces>();
builder.Services.AddScoped<IproductServices, ProductServices>();
builder.Services.AddScoped<IproductRepository, ProductRepository>();
builder.Services.AddScoped<IEmailSender, SendingEmail>();
builder.Services.AddScoped<ICartRepository, cartRepository>();
builder.Services.AddScoped<ICartServices, CartServieces>();
builder.Services.AddScoped<ICheckOut, CheckOut>();
builder.Services.AddScoped<IChechOutRepo, ChechOutRepo>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.Configure<stripesetting>(builder.Configuration.GetSection("Stripe"));
StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})

        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("jwtOption")["secretkey"]))
            };
        });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using (var scope = app.Services.CreateScope())
{
    var seedData = scope.ServiceProvider.GetRequiredService<ISeedData>();
    await seedData.DataSeedAsync();
    await seedData.IdentityDataSeedAsync();
}
//������� ��� ��� ������ ���� ����� ��� �� ���� ��

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors(userPolicy);
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();



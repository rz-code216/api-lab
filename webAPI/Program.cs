using Microsoft.EntityFrameworkCore;
using NLog.Web;
using Repositories;
using Repositories;
using Repository;
using Service;
using Services;
using Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<storeDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("home")));
builder.Services.AddTransient<IUsersRepository, UsersRepository>();
builder.Services.AddTransient<IUserService, UsersService>();
builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddTransient<IOrdersService, OrdersService>();
builder.Services.AddTransient<IOrdersRepository, OrdersRepository>();

builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();
app.MapControllers();

app.Run();
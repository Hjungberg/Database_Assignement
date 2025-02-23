

using Business.Services;
using Data.Contexts;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation;

var services = new ServiceCollection()
   .AddDbContext<DataContext>(x => x.UseSqlServer())
   .AddScoped<CustomerRepository>()
   .AddScoped<UserRepository>()
   .AddScoped<ProjectRepository>()
   .AddScoped<CustomerService>()
   .AddScoped<UserService>()
   .AddScoped<MenuDialog>()
   .AddScoped<ProjectService>()
   .BuildServiceProvider();

var menuDialogs = services.GetRequiredService<MenuDialog>();
await menuDialogs.MenuOptions();
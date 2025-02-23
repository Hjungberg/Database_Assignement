

using Business.Services;
using Data.Contexts;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation;

var services = new ServiceCollection()
   .AddDbContext<DataContext>(x => x.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\Database_Assignement\\Data\\Databases\\local_db.mdf;Integrated Security=True;Connect Timeout=3"))
   .AddScoped<CustomerRepository>()
   .AddScoped<UserRepository>()
   .AddScoped<ProjectRepository>()
   .AddScoped<StatusRepository>()
   .AddScoped<SeviceRepository>()
   .AddScoped<CustomerService>()
   .AddScoped<UserService>()
   .AddScoped<ProjectService>()
   .AddScoped<StatusService>()
   .AddScoped<ServiceService>()
   .AddScoped<MenuDialog>()
   .BuildServiceProvider();

var menuDialogs = services.GetRequiredService<MenuDialog>();
await menuDialogs.MenuOptions();
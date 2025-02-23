
using Business.Factories;
using Business.Models;
using Business.Services;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Presentation;

public class MenuDialog(CustomerService customerService, UserService userService, ProjectService projectService, StatusService statusService, ServiceService serviceService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly UserService _userService = userService;
    private readonly ProjectService _projectService = projectService;
    private readonly StatusService _statusService = statusService;
    private readonly ServiceService _serviceService = serviceService;



    public async Task MenuOptions()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("1. Projects");
            Console.WriteLine("2. Customers");
            Console.WriteLine("3. Users");
            Console.WriteLine("0. Exit");
            Console.Write("");
            Console.Write("Choose your menu option: ");
            var option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    await MenuProjects();
                    break;
                case "2":
                    await MenuCustomer();
                    break;
                case "3":
                    await MenuUsers();
                    break;
                case "0":
                    running = false;
                    break;
                default:
                    Console.WriteLine("You must enter a valid option.");
                    Console.ReadKey();
                    break;
            }
        }
    }
    public async Task MenuProjects()
    {
        Console.Clear();
        Console.WriteLine("1. View all Projects");
        Console.WriteLine("2. Create Project");
        Console.WriteLine("3. Update Project");
        Console.WriteLine("4. Delete Project");
        Console.WriteLine("0. Exit");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                await ShowAllProjects();
                Console.ReadKey();
                break;
            case "2":
                await ProjectCreate();
                break;
            case "3":
                await UpdateProject();
                break;
            case "4":
                await DeleteProject();
                break;
            case "0":
                break;
            default:
                Console.WriteLine("You must enter a valid option.");
                Console.ReadKey();
                break;
        }
    }
    public async Task MenuUsers()
    {
        Console.Clear();
        Console.WriteLine("1. View all Users");
        Console.WriteLine("2. Create User");
        Console.WriteLine("3. Update User");
        Console.WriteLine("4. Delete User");
        Console.WriteLine("0. Exit");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                await ShowAllUsers();
                Console.ReadKey();
                break;
            case "2":
                await UserCreate();
                break;
            case "3":
                await UpdateUser();
                break;
            case "4":
                DeleteUser();
                break;
            case "0":
                break;
            default:
                Console.WriteLine("You must enter a valid option.");
                Console.ReadKey();
                break;
        }
    }
    public async Task MenuCustomer()
    {
        Console.Clear();
        Console.WriteLine("1. View all Customers");
        Console.WriteLine("2. Create Customer");
        Console.WriteLine("3. Update Customer");
        Console.WriteLine("4. Delete Customer");
        Console.WriteLine("0. Exit");
        var option = Console.ReadLine();
        switch (option)
        {
            case "1":
                await ShowAllCustomers();
                Console.ReadKey();
                break;
            case "2":
                await CustomerCreate();
                break;
            case "3":
                await UpdateCustomer();
                break;
            case "4":
                await DeleteCustomer();
                break;
            case "0":
                break;
            default:
                Console.WriteLine("You must enter a valid option.");
                Console.ReadKey();
                break;
        }
    }
    public async Task ShowAllUsers()
    {
        var users = await _userService.GetusersAsync();
        Console.Clear();
        foreach (var user in users)
        {
            Console.WriteLine($"Id: {user.Id}, {user.FirstName} {user.LastName}, {user.Email}");
        }
        Console.WriteLine("");
    }
    public async Task UserCreate()
    {
        Console.Clear();
        Console.WriteLine("Enter the user's First Name: ");
        var firstname = Console.ReadLine();
        Console.WriteLine("Enter the user's Last Name: ");
        var lastname = Console.ReadLine();
        Console.WriteLine("Enter the user's Email: ");
        var email = Console.ReadLine();

        var user = new UserRegistrationForm
        {
            FirstName = firstname!,
            LastName = lastname!,
            Email = email!,
        };
        var result = await _userService.CreateuserAsync(user);
        if (result)
        {
            Console.WriteLine("User created successfully.");
        }
        else
        {
            Console.WriteLine("An error occurred while creating the user.");
        }
        Console.ReadKey();
    }
    public async Task UpdateUser()
    {
        Console.Clear();
        await ShowAllUsers();
        Console.WriteLine("");
        Console.WriteLine("Enter the user's Id: ");

        var id = Convert.ToInt32(Console.ReadLine());
        var user = await _userService.GetuserAsync(id);
        Console.WriteLine($"Enter the user's First Name: ");
        var firstname = Console.ReadLine();
        Console.WriteLine("Enter the user's Last Name: ");
        var lastname = Console.ReadLine();
        Console.WriteLine("Enter the user's Email: ");
        var email = Console.ReadLine();

        var updatedUserEntity = UserFactory.Create(new UserRegistrationForm
        {
            FirstName = firstname!,
            LastName = lastname!,
            Email = email!
        });
        updatedUserEntity.Id = user.Id;

        var result = await _userService.UpdateuserAsync(updatedUserEntity);
        if (result)
        {
            Console.WriteLine("User updated successfully.");
        }
        else
        {
            Console.WriteLine("An error occurred while updating the user.");
        }

        Console.ReadKey();
    }
    public async void DeleteUser()
    {
        Console.Clear();
        await ShowAllUsers();
        Console.WriteLine("");
        Console.WriteLine("Enter the user's Id: ");

        var id = Convert.ToInt32(Console.ReadLine());
        var user = await _userService.GetuserAsync(id);


        var result = await _userService.DeleteuserAsync(user.Id);
        if (result)
        {
            Console.WriteLine("User updated successfully.");
        }
        else
        {
            Console.WriteLine("An error occurred while updating the user.");
        }

        Console.ReadKey();
    }
    public async Task ShowAllCustomers()
    {
        var customer = await _customerService.GetCustomersAsync();
        Console.Clear();
        foreach (var customers in customer)
        {
            Console.WriteLine($"Id: {customers.Id}, {customers.Name} ");
        }
        Console.WriteLine("");
    }
    public async Task CustomerCreate()
    {
        Console.Clear();
        Console.WriteLine("Enter the Customers Name: ");
        var name = Console.ReadLine();


        var customer = new CustomerRegistrationForm
        {
            CustomerName = name!,

        };
        var result = await _customerService.CreateCustomerAsync(customer);
        if (result)
        {
            Console.WriteLine("Customer created successfully.");
        }
        else
        {
            Console.WriteLine("An error occurred while creating the user.");
        }
        Console.ReadKey();
    }
    public async Task UpdateCustomer()
    {
        await ShowAllCustomers();
        Console.WriteLine("");

        Console.WriteLine("Enter the Customer's Id: ");

        var id = Convert.ToInt32(Console.ReadLine());
        var customer = await _customerService.GetCustomerAsync(id);
        Console.WriteLine($"Enter the Customer's Name: ");
        var name = Console.ReadLine();

        CustomerEntity updatedCustomerEntity = new CustomerEntity
        {
            Id = id,
            Name = name!
        };
        //var updatedCustomerEntity = CustomerFactory.Create(new Customer
        //{
        //    id = customer.Id,
        //    Name = name!,
        //});

        var result = await _customerService.UpdateCustomerAsync(updatedCustomerEntity);
        if (result)
        {
            Console.WriteLine("User updated successfully.");
        }
        else
        {
            Console.WriteLine("An error occurred while updating the user.");
        }

    }

    public async Task DeleteCustomer()
    {
        Console.Clear();
        await ShowAllCustomers();
        Console.WriteLine("");
        Console.WriteLine("Enter the Customer's Id: ");
        Console.WriteLine();
        var id = Convert.ToInt32(Console.ReadLine());
        var customer = _customerService.GetCustomerAsync(id);

        var result = _customerService.DeleteCustomerAsync(customer.Id);



    }

    public async Task ShowAllProjects()
    {
        var projects = await _projectService.GetprojectsAsync();
        Console.Clear();
        foreach (var project in projects)
        {
            Console.WriteLine($"Id: {project!.Id}, {project.Name} ");
            Console.WriteLine($"{project.Description} ");
            Console.WriteLine($"Startdate: {project.StartDate} - {project.EndDate}");
            var customer = await _customerService.GetCustomerAsync(project.CustomerId);
            var user = await _userService.GetuserAsync(project.UserId);
            Console.WriteLine($"Customer: {customer!.Name} User: {user!.FirstName} {user.LastName}");
            var status = await _statusService.GetStatusAsync(project.StatusId);
            Console.WriteLine($"Status: {status!.Statustext}");
            var serviceService = await _serviceService.GetServiceAsync(project.ServiceId);
            Console.WriteLine($"Service: {serviceService!.Name}");
            Console.WriteLine("-----------------------------------");
        }
        Console.WriteLine("");

    }
    public async Task ProjectCreate()
    {
        Console.Clear();
        Console.WriteLine("Project Name: ");
        var name = Console.ReadLine();
        Console.WriteLine("Description: ");
        var description = Console.ReadLine();
        Console.WriteLine("Start date: ");
        var start_date = Console.ReadLine();
        Console.WriteLine("End date: ");
        var end_date = Console.ReadLine();
        Console.WriteLine("Customer id: ");
        var customer_id = Console.ReadLine();
        Console.WriteLine("Status id: ");
        var status_id = Console.ReadLine();
        Console.WriteLine("Service id: ");
        var Service_id = Console.ReadLine();
        Console.WriteLine("User id: ");
        var user_id = Console.ReadLine();


        var project = new ProjectRegistrationForm
        {
            Name = name!,
            Description = description!,
            StartDate = DateTime.Parse(start_date!),
            EndDate = DateTime.Parse(end_date!),
            CustomerId = Convert.ToInt32(customer_id),
            StatusId = Convert.ToInt32(status_id),
            ServiceId = Convert.ToInt32(Service_id),
            UserId = Convert.ToInt32(user_id)
                


        };
        var result = await _projectService.CreateprojectAsync(project);
        if (result)
        {
            Console.WriteLine("Project created successfully.");
        }
        else
        {
            Console.WriteLine("An error occurred while creating the project.");
        }
        Console.ReadKey();
    }
    public async Task UpdateProject()
    {
        Console.WriteLine("Enter the Project's Id: ");
        var id = Convert.ToInt32(Console.ReadLine());
        var project = await _projectService.GetprojectAsync(id);
        Console.WriteLine($"Project's Name({project.Name}): ");
        var name = Console.ReadLine();
        if (string.IsNullOrEmpty(name))
        {
            name = project.Name;
        }
        Console.WriteLine($"Description({project.Description}): ");
        var description = Console.ReadLine();
        if (string.IsNullOrEmpty(description))
        {
            description = project.Description;
        }
        Console.WriteLine($"Start Date({project.StartDate}): ");
        var start_date = Console.ReadLine();
        if (string.IsNullOrEmpty(start_date))
        {
            start_date = project.StartDate.ToString();
        }
        Console.WriteLine($"End Date({project.EndDate}): ");
        var end_date = Console.ReadLine();
        if (string.IsNullOrEmpty(end_date))
        {
            end_date = project.EndDate.ToString();
        }
        Console.WriteLine($"Customer Id({project.CustomerId}): ");
        var customer_id = Console.ReadLine();
        if (string.IsNullOrEmpty(customer_id))
        {
            customer_id = project.CustomerId.ToString();
        }
        Console.WriteLine($"Status Id({project.StatusId}): ");
        var status_id = Console.ReadLine();
        if (string.IsNullOrEmpty(status_id))
        {
            status_id = project.StatusId.ToString();
        }
        Console.WriteLine($"Service Id({project.ServiceId}): ");
        var service_id = Console.ReadLine();
        if (string.IsNullOrEmpty(service_id))
        {
            service_id = project.ServiceId.ToString();
        }
        Console.WriteLine($"User Id({project.UserId}): ");
        var user_id = Console.ReadLine();
        if (string.IsNullOrEmpty(user_id))
        {
            user_id = project.UserId.ToString();
        }

        var updatedProjectEntity = new ProjectEntity
        {
            Id = id,
            Name = name!,
            Description = description!,
            StartDate = DateTime.Parse(start_date!),
            EndDate = DateTime.Parse(end_date!),
            CustomerId = Convert.ToInt32(customer_id),
            StatusId = Convert.ToInt32(status_id),
            ServiceId = Convert.ToInt32(service_id),
            UserId = Convert.ToInt32(user_id)
        };
        var result = await _projectService.UpdateprojectAsync(updatedProjectEntity);
        if (result)
        {
            Console.WriteLine("Project updated successfully.");
        }
        else
        {
            Console.WriteLine("An error occurred while updating the project.");
        }
        Console.ReadKey();
    }
    public async Task DeleteProject()
    {

    }
}

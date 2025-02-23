
using Business.Models;
using Business.Services;

namespace Presentation;

public class MenuDialog(CustomerService customerService, UserService userService)
{
    private readonly CustomerService _customerService = customerService;
    private readonly UserService _userService = userService;

    public async Task MenuOptions()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("1. users");
            Console.WriteLine("2. Customers");
            Console.WriteLine("3. Users");
            Console.WriteLine("0. Exit");
            Console.Write("");
            Console.Write("Choose your menu option");
            var option = Console.ReadLine();
            switch (option) 
            {
                case "1":
                    Menuuser();
                    break;
                case "2":
                    Menuuser();
                    break;
                case "3":
                    Menuuser();
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
    public  void Menuuser()
    {
        Console.Clear();
        Console.WriteLine("1. View all users");
        Console.WriteLine("2. Create user");
        Console.WriteLine("3. Update user");
        Console.WriteLine("4. Delete user");
        Console.WriteLine("0. Exit");
    }
    public void MenuCustomer()
    {
        Console.Clear();
        Console.WriteLine("1. View all Customers");
        Console.WriteLine("2. Create Customer");
        Console.WriteLine("3. Update Customer");
        Console.WriteLine("4. Delete Customer");
        Console.WriteLine("0. Exit");
    }
    public void MenuUsers()
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

                break;
            case "2":
                UserCreate();
                break;
            case "3":

                break;
            case "0":
                break;
            default:
                Console.WriteLine("You must enter a valid option.");
                Console.ReadKey();
                break;
        }
    }
    public async void UserCreate()
    {
        Console.Clear();
        Console.WriteLine("Enter the user's name:");
        var firstname = Console.ReadLine();
        Console.WriteLine("Enter the user's email:");
        var lastname = Console.ReadLine();
        Console.WriteLine("Enter the user's password:");
        var email = Console.ReadLine();

        var user = new UserRegistrationForm
        {
            FirstName = firstname,
            LastName = lastname,
            Email = email,
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
}

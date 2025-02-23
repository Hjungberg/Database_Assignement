using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class CustomerFactory
{
    public static Customer? Create(CustomerEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        Name = entity.Name,
    };

    public static CustomerEntity? Create(CustomerRegistrationForm form) => form == null ? null : new()
    {
        Name = form.CustomerName
    };

  
}

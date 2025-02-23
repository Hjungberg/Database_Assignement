
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repository;
using System.Diagnostics;

namespace Business.Services;

public class CustomerService
{
    private readonly CustomerRepository _customerRepository;

    public CustomerService(CustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
        try
        {
            var customerEntity = CustomerFactory.Create(form);
            await _customerRepository.AddAsync(customerEntity!);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<IEnumerable<Customer?>> GetCustomersAsync()
    {
        var customerEntities = await _customerRepository.GetAsync();
        return customerEntities.Select(CustomerFactory.Create);
    }

    public async Task<Customer?> GetCustomerAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);
        return CustomerFactory.Create(customerEntity!);
    }

    public async Task<bool> UpdateCustomerAsync(CustomerEntity customer)
    {
        try
        {
            var customerEntity = new CustomerEntity
            {
                Id = customer.Id,
                Name = customer.Name
            };
            await _customerRepository.UpdateAsync(customerEntity);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            return false;
        }
    }

    public async Task<bool> DeleteCustomerAsync(int id)
    {
        var customerEntity = await _customerRepository.GetAsync(x => x.Id == id);
        if (customerEntity != null)
        {
            await _customerRepository.RemoveAsync(customerEntity);
            return true;
        }
        return false;
    }
}

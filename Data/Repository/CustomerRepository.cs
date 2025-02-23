

using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context)
{
}

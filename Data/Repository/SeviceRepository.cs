

using Data.Contexts;
using Data.Entities;

namespace Data.Repository;

public class SeviceRepository(DataContext context) : BaseRepository<ServiceEntity>(context)
{
}



using Data.Contexts;
using Data.Entities;

namespace Data.Repository;

public class UserRepository(DataContext context) : BaseRepository<UserEntity>(context)
{
}
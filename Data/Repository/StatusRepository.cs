

using Data.Contexts;
using Data.Entities;

namespace Data.Repository;

public class StatusRepository(DataContext context) : BaseRepository<StatusEntity>(context)
{
    public static implicit operator StatusRepository(ProjectRepository v)
    {
        throw new NotImplementedException();
    }
}

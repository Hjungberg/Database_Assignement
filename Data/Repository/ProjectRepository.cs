

using Data.Contexts;
using Data.Entities;

namespace Data.Repository;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context)

{
}

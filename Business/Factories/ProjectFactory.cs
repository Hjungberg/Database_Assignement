using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectFactory
{
    public static ProjectEntity? Create(ProjectRegistrationForm form) => form == null ? null : new()
    {
        Name = form.Name,
        Description = form.Description,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        CustomerId = form.CustomerId,
        StatusId = form.StatusId,
        ServiceId = form.ServiceId,
        UserId = form.UserId

    };
    public static Project? Create(ProjectEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Description = entity.Description,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        CustomerId = entity.CustomerId,
        StatusId = entity.StatusId,
        ServiceId = entity.ServiceId,
        UserId = entity.UserId

    };
}
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ServiceFactory
{
    public static Service? Create(ServiceEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        Name = entity.Name,
    };

    public static ServiceEntity? Create(ServiceRegistrationForm form) => form == null ? null : new()
    {
        Name = form.Name
    };


}
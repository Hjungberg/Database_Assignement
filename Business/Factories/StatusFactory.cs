using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class StatusFactory
{
    public static Status? Create(StatusEntity entity) => entity == null ? null : new()
    {
        Id = entity.Id,
        Statustext = entity.Status,
    };

    public static StatusEntity? Create(StatusRegistrationForm form) => form == null ? null : new()
    {
        Status = form.Status
    };


}



using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<ProjectEntity> Project { get; set; }
    public DbSet<ServiceEntity> Services { get; set; }
    public DbSet<StatusEntity> Status { get; set; }
    public DbSet<UserEntity> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var status1 = new StatusEntity { Id = 1, Status = "Ej påbörjat" };
        var status2 = new StatusEntity { Id = 2, Status = "Pågående" };
        var status3 = new StatusEntity { Id = 3, Status = "Avslustad" };

        var service = new ServiceEntity { Id = 1, Name = "Konsulttid" };

        var service2 = new ServiceEntity { Id = 2, Name = "Utveckling" };

        modelBuilder.Entity<StatusEntity>().HasData(status1, status2, status3);
        modelBuilder.Entity<ServiceEntity>().HasData(service, service2);

        base.OnModelCreating(modelBuilder);
    }

}

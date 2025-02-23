using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repository;
using System.Diagnostics;

namespace Business.Services
{
    public class ServiceService
    {
        private readonly SeviceRepository _serviceRepository;

        public ServiceService(SeviceRepository serviceRepository)
        {
            _serviceRepository = serviceRepository;
        }

        public async Task<Service?> GetServiceAsync(int id)
        {
            var statusEntity = await _serviceRepository.GetAsync(x => x.Id == id);
            return ServiceFactory.Create(statusEntity!);
        }
    }

}

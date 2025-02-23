using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repository;
using System.Diagnostics;

namespace Business.Services
{
    public class StatusService
    {
        private readonly StatusRepository _statusRepository;

        public StatusService(StatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<Status?> GetStatusAsync(int id)
        {
            var serviceEntity = await _statusRepository.GetAsync(x => x.Id == id);
            return StatusFactory.Create(serviceEntity!);
        }
    }

}

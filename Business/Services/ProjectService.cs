using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repository;
using System.Diagnostics;

namespace Business.Services
{
    public class ProjectService
    {
        private readonly ProjectRepository _projectRepository;

        public ProjectService(ProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<bool> CreateprojectAsync(ProjectRegistrationForm form)
        {
            try
            {
                var projectEntity = ProjectFactory.Create(form);
                await _projectRepository.AddAsync(projectEntity!);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<IEnumerable<Project?>> GetprojectsAsync()
        {
            var projectEntities = await _projectRepository.GetAsync();
            return projectEntities.Select(ProjectFactory.Create);
        }

        public async Task<Project?> GetprojectAsync(int id)
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
            return ProjectFactory.Create(projectEntity!);
        }

        public async Task<bool> UpdateprojectAsync(ProjectEntity project)
        {
            try
            {
                await _projectRepository.UpdateAsync(project);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteprojectAsync(int id)
        {
            try
            {
                var projectEntity = await _projectRepository.GetAsync(x => x.Id == id);
                if (projectEntity == null)
                {
                    return false;
                }

                await _projectRepository.RemoveAsync(projectEntity);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}
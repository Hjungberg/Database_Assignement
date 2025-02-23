using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Repository;
using System.Diagnostics;

namespace Business.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CreateuserAsync(UserRegistrationForm form)
        {
            try
            {
                var userEntity = UserFactory.Create(form);
                await _userRepository.AddAsync(userEntity!);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<IEnumerable<User?>> GetusersAsync()
        {
            var userEntities = await _userRepository.GetAsync();
            return userEntities.Select(UserFactory.Create);
        }

        public async Task<User?> GetuserAsync(int id)
        {
            var userEntity = await _userRepository.GetAsync(x => x.Id == id);
            return UserFactory.Create(userEntity!);
        }

        public async Task<bool> UpdateuserAsync(UserEntity user)
        {
            try
            {
                var userEntity = UserFactory.Create(user);
                if (userEntity == null)
                {
                    return false;
                }

                await _userRepository.UpdateAsync(user);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteuserAsync(int id)
        {
            try
            {
                var userEntity = await _userRepository.GetAsync(x => x.Id == id);
                if (userEntity == null)
                {
                    return false;
                }

                await _userRepository.RemoveAsync(userEntity);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        //public async Task<bool> UpdateuserAsync(CustomerEntity? updatedCustomerEntity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
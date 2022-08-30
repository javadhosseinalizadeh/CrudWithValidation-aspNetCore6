using SampleCrud.Models.Contracts.Repositories;
using SampleCrud.Models.Entities;

namespace SampleCrud.Models.Contracts.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _userRepository.Delete(id, cancellationToken);
        }

        public async Task EnsureDoesNotExist(string personnelCode, CancellationToken cancellationToken)
        {
            var record = await _userRepository.Get(personnelCode, cancellationToken);
            if (record != null)
            {
                throw new Exception($"Personnel code ' {personnelCode} ' is already exists!");
            }
        }

        public async Task EnsureExists(string personnelCode, CancellationToken cancellationToken)
        {
            var record = await _userRepository.Get(personnelCode, cancellationToken);
            if (record == null)
            {
                throw new Exception($"Personnel code ' {personnelCode} ' doesn't exists!");
            }
        }

        public async Task EnsureExists(Guid id, CancellationToken cancellationToken)
        {
            var record = await _userRepository.Get(id, cancellationToken);
            if (record == null)
            {
                throw new Exception($"Personnel code ' {id} ' doesn't exists!");
            }
        }

        public async Task<User> Get(Guid id, CancellationToken cancellationToken)
        {
            var record = await _userRepository.Get(id, cancellationToken);
            if (record == null)
            {
                throw new Exception($"Personnel code ' {id} ' doesn't exists!");
            }
            return record;
        }

        public async Task<User> Get(string personnelCode, CancellationToken cancellationToken)
        {
            var record = await _userRepository.Get(personnelCode, cancellationToken);
            if (record == null)
            {
                throw new Exception($"Personnel code ' {personnelCode} ' doesn't exists!");
            }
            return record;
        }

        public Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            return _userRepository.GetAll(cancellationToken);
        }

        public async Task Set(User user, CancellationToken cancellationToken)
        {
            await _userRepository.Add(user, cancellationToken);
        }

        public async Task Update(User user, CancellationToken cancellationToken)
        {
            var result = await _userRepository.Get(user, cancellationToken);
            if (result == null)
                await _userRepository.Update(user,cancellationToken);
            else
            {
                throw new Exception($" {user.PersonnelCode} is already exists");
            }
        }
    }
}

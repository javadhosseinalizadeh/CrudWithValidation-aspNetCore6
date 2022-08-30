using SampleCrud.Models.Contracts.Services;
using SampleCrud.Models.Entities;

namespace SampleCrud.Models.Contracts.AppServices
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _service;
        public UserAppService(IUserService service)
        {
            _service = service;
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            await _service.EnsureExists(id, cancellationToken);
            await _service.Delete(id, cancellationToken);
        }

        public async Task<User> Get(Guid id, CancellationToken cancellationToken)
        {
            return await _service.Get(id, cancellationToken);
        }

        public async Task<User> Get(string personnelCode, CancellationToken cancellationToken)
        {
            return await _service.Get(personnelCode, cancellationToken);
        }

        public async Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            return await _service.GetAll(cancellationToken);
        }

        public async Task Set(User user, CancellationToken cancellationToken)
        {
            await _service.EnsureDoesNotExist(user.PersonnelCode, cancellationToken);
            await _service.Set(user, cancellationToken);
        }

        public async Task Update(User user, CancellationToken cancellationToken)
        {
            await _service.EnsureExists(user.Id, cancellationToken);
           
            await _service.Update(user, cancellationToken);
            
        }
    }
}

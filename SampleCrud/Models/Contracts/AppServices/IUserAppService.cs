using SampleCrud.Models.Entities;

namespace SampleCrud.Models.Contracts.AppServices
{
    public interface IUserAppService
    {
        Task<List<User>> GetAll(CancellationToken cancellationToken);
        Task Set(User user, CancellationToken cancellationToken);
        Task<User> Get(Guid id, CancellationToken cancellationToken);
        Task<User> Get(string personnelCode, CancellationToken cancellationToken);
        Task Update(User user, CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);
    }
}

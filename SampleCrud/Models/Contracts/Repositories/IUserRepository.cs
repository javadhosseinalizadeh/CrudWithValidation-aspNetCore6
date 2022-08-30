using SampleCrud.Models.Entities;

namespace SampleCrud.Models.Contracts.Repositories
{
    public interface IUserRepository
    {
        #region Commands
        Task Add(User user, CancellationToken cancellationToken);
        Task Update(User user, CancellationToken cancellationToken);
        Task Delete(Guid id, CancellationToken cancellationToken);
        #endregion

        #region Queries
        Task<List<User>> GetAll(CancellationToken cancellationToken);
        Task<User>? Get(Guid id, CancellationToken cancellationToken);
        Task<User>? Get(string PersonnelCode, CancellationToken cancellationToken);
        Task<User>? Get(User model, CancellationToken cancellationToken);
        #endregion
    }
}
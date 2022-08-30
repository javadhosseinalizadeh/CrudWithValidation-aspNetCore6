using Microsoft.EntityFrameworkCore;
using SampleCrud.Models.Data;
using SampleCrud.Models.Entities;

namespace SampleCrud.Models.Contracts.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CrudDbContext _context;
        public UserRepository(CrudDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user, CancellationToken cancellationToken)
        {
            User record = new()
            {
                Name = user.Name,
                PersonnelCode = user.PersonnelCode,
                IsActive = user.IsActive,
            };
            await _context.Users.AddAsync(record, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task Delete(Guid id, CancellationToken cancellationToken)
        {
            var record = await _context.Users.Where(u => u.Id == id).SingleAsync(cancellationToken);
            _context.Remove(record);
            await _context.SaveChangesAsync(cancellationToken);
        }

        public Task<User>? Get(Guid id, CancellationToken cancellationToken)
        {
            var record = _context.Users.Where(u => u.Id == id).Select(u => new User()
            {
                Id = u.Id,
                Name = u.Name,
                PersonnelCode = u.PersonnelCode,
                IsActive = u.IsActive,
            }).SingleOrDefaultAsync(cancellationToken);
            return record;
        }

        public Task<User>? Get(string PersonnelCode, CancellationToken cancellationToken)
        {
            var record = _context.Users.Where(u => u.PersonnelCode == PersonnelCode).Select(u => new User()
            {
                Id = u.Id,
                Name = u.Name,
                PersonnelCode = u.PersonnelCode,
                IsActive = u.IsActive,
            }).SingleOrDefaultAsync(cancellationToken);
            return record;
        }

        public async Task<User>? Get(User model, CancellationToken cancellationToken)
        {
            var users = _context.Users.FirstOrDefault(u => u.PersonnelCode == model.PersonnelCode && u.Id != model.Id);
            //return await Task.FromResult(users);
            return users;
        }

        public async Task<List<User>> GetAll(CancellationToken cancellationToken)
        {
            return await _context.Users.Select(u => new User()
            {
                Id = u.Id,
                Name = u.Name,
                PersonnelCode = u.PersonnelCode,
                IsActive = u.IsActive,
            }).ToListAsync(cancellationToken);
        }

        public async Task Update(User user, CancellationToken cancellationToken)
        {
            User record = await _context.Users.Where(u => u.Id == user.Id).SingleAsync(cancellationToken);

            record.Name = user.Name;
            record.PersonnelCode = user.PersonnelCode;
            record.IsActive = user.IsActive;

            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}

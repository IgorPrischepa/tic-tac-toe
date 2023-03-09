using Microsoft.EntityFrameworkCore;
using TicTacToeApi.Dal.Db;
using TicTacToeApi.Dal.Entities;
using TicTacToeApi.Dal.Repos.Contract;

namespace TicTacToeApi.Dal.Repos.Implementation
{
    public sealed class UserRepo : IUserRepo
    {
        private readonly AppDbContext _db;

        public UserRepo(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public async Task<Guid> AddAsync(UserEntity newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException(nameof(newUser));

            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();
            return newUser.UserId;
        }

        public async Task DeleteAsync(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                throw new ArgumentOutOfRangeException("User GUID can't be empty");
            }

            UserEntity? targetUser = await _db.Users.FirstOrDefaultAsync(_ => _.UserId == userId);
            if (targetUser != null)
            {
                _db.Remove(targetUser);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<UserEntity?> FindByEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            return await _db.Users.Include(_ => _.Roles).FirstOrDefaultAsync(_ => _.Email == email);
        }
    }
}
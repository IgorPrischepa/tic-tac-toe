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

        public async Task<int> AddAsync(UserEntity newUser)
        {
            if (newUser == null)
                throw new ArgumentNullException(nameof(newUser));

            await _db.Users.AddAsync(newUser);
            await _db.SaveChangesAsync();
            return newUser.Id;
        }

        public async Task DeleteAsync(int userId)
        {
            if (userId > 0)
            {
                UserEntity? targetUser = await _db.Users.FirstOrDefaultAsync(_ => _.Id == userId);
                if (targetUser != null)
                {
                    _db.Remove(targetUser);
                    await _db.SaveChangesAsync();
                }
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
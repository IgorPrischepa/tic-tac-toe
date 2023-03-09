using Microsoft.EntityFrameworkCore;
using TicTacToeApi.Dal.Db;
using TicTacToeApi.Dal.Entities;
using TicTacToeApi.Dal.Repos.Contract;

namespace TicTacToeApi.Dal.Repos.Implementation
{
    public sealed class RoleRepo : IRoleRepo
    {
        private readonly AppDbContext _db;

        public RoleRepo(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        public async Task<RoleEntity?> FindByNameAsync(string playerRoleName)
        {
            if (string.IsNullOrEmpty(playerRoleName))
            {
                throw new ArgumentException($"'{nameof(playerRoleName)}' cannot be null or empty.", nameof(playerRoleName));
            }

            return await _db.Roles.FirstOrDefaultAsync(_ => _.Name == playerRoleName);
        }
    }
}

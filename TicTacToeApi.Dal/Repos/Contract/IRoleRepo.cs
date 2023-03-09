using TicTacToeApi.Dal.Entities;

namespace TicTacToeApi.Dal.Repos.Contract
{
    public interface IRoleRepo
    {
        Task<RoleEntity?> FindByNameAsync(string playerRoleName);
    }
}
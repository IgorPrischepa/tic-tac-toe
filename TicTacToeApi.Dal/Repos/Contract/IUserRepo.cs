using TicTacToeApi.Dal.Entities;

namespace TicTacToeApi.Dal.Repos.Contract
{
    public interface IUserRepo
    {
        Task<int> AddAsync(UserEntity newUser);

        Task DeleteAsync(int userId);

        Task<UserEntity?> FindByEmailAsync(string email);
    }
}

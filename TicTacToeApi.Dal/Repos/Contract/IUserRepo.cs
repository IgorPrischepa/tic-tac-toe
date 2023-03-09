using TicTacToeApi.Dal.Entities;

namespace TicTacToeApi.Dal.Repos.Contract
{
    public interface IUserRepo
    {
        Task<Guid> AddAsync(UserEntity newUser);

        Task DeleteAsync(Guid userId);

        Task<UserEntity?> FindByEmailAsync(string email);
    }
}

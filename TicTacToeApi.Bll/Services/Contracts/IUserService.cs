using System.Threading.Tasks;
using TicTacToeApi.Bll.Models;

namespace TicTacToeApi.Bll.Services.Contracts
{
    public interface IUserService
    {
        Task<BaseUserModel?> GetUserAsync(string email, string password);

        Task DeleteAsync(Guid userId);

        Task RegisterUserAsync(AddUserModel addUserModel);
    }
}
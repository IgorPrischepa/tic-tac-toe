using TicTacToeApi.Bll.Models;

namespace TicTacToeApi.Bll.Services.Contracts
{
    public interface IJwtAuthService
    {
        Task<string> LoginAsync(LoginUserModel user);
    }
}
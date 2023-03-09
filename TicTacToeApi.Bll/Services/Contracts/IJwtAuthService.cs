namespace TicTacToeApi.Bll.Services.Contracts
{
    public interface IJwtAuthService
    {
        Task<string> LoginAsync(LoginUserDto user);
    }
}
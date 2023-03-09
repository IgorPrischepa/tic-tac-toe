namespace TicTacToeApi.Bll.Models
{
    public sealed class AddUserModel
    {
        public string Email { get; set; } = null!;

        public string NickName { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
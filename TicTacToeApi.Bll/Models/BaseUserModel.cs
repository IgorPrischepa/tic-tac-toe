namespace TicTacToeApi.Bll.Models
{
    public class BaseUserModel
    {
        public string Email { get; set; } = null!;

        public string Nickname { get; set; } = null!;

        public IEnumerable<string> Roles { get; set; } = null!;
    }
}
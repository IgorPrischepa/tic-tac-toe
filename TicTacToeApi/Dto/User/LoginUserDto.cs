using System.ComponentModel.DataAnnotations;

namespace TicTacToeApi.Dto.User
{
    public sealed class LoginUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
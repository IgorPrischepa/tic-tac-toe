using System.ComponentModel.DataAnnotations;

namespace TicTacToeApi.Dto.User
{
    public class AddUserDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [MinLength(4)]
        public string Nickname { get; set; } = null!;


        [Required]
        [MaxLength(100)]
        [MinLength(6)]
        public string Password { get; set; } = null!;
    }
}
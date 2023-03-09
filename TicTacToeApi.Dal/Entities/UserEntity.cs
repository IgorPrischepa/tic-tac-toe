namespace TicTacToeApi.Dal.Entities
{
    public sealed class UserEntity
    {
        public int Id { get; set; }

        public string NickName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public ICollection<RoleEntity> Roles { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public int CurrentGameRoomId { get; set; }

        public GameRoomEntity? CurrentGameRoom { get; set; }
    }
}
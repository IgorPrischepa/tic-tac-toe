namespace TicTacToeApi.Dal.Entities
{
    public sealed class UserEntity
    {
        public Guid UserId { get; set; }

        public string NickName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public ICollection<RoleEntity> Roles { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public IList<GameRoomEntity>? Games { get; set; }

        public IList<PlayerTurnEntity>? TurnsHistory { get; set; }
    }
}
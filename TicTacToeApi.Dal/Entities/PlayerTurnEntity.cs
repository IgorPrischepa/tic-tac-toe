namespace TicTacToeApi.Dal.Entities
{
    public sealed class PlayerTurnEntity
    {
        public Guid Id { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public int PlayerId { get; set; }

        public UserEntity Player { get; set; } = null!;

        public int GameRoomId { get; set; }

        public GameRoomEntity GameRoom { get; set; } = null!;

        public DateTime Timestamp { get; set; }
    }
}
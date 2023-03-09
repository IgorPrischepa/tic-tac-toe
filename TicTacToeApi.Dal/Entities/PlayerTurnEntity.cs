namespace TicTacToeApi.Dal.Entities
{
    public sealed class PlayerTurnEntity
    {
        public Guid PlayerTurnId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public Guid PlayerId { get; set; }

        public UserEntity Player { get; set; } = null!;

        public Guid GameRoomId { get; set; }

        public GameRoomEntity GameRoom { get; set; } = null!;

        public DateTime Timestamp { get; set; }
    }
}
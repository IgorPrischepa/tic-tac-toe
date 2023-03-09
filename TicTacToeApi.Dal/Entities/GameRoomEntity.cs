using System.ComponentModel.DataAnnotations;

namespace TicTacToeApi.Dal.Entities
{
    public sealed class GameRoomEntity
    {
        public Guid Id { get; set; }

        public int FirstPlayerId { get; set; }

        public UserEntity? FirstPlayer { get; set; }

        public int SecondPlayerId { get; set; }

        public UserEntity? SecondPlayer { get; set; }

        public ICollection<PlayerTurnEntity> GameHistory { get; set; } = null!;
    }
}
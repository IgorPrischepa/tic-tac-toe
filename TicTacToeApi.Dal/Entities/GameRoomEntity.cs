using System.ComponentModel.DataAnnotations;

namespace TicTacToeApi.Dal.Entities
{
    public sealed class GameRoomEntity
    {
        public Guid GameRoomId { get; set; }

        public Guid FirstPlayerId { get; set; }

        public UserEntity? FirstPlayer { get; set; }

        public Guid SecondPlayerId { get; set; }

        public UserEntity? SecondPlayer { get; set; }

        public ICollection<PlayerTurnEntity> GameHistory { get; set; } = null!;
    }
}
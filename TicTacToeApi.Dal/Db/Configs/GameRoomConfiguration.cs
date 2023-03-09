using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicTacToeApi.Dal.Entities;

namespace TicTacToeApi.Dal.Db.Configs
{
    internal class GameRoomConfiguration : IEntityTypeConfiguration<GameRoomEntity>
    {
        public void Configure(EntityTypeBuilder<GameRoomEntity> builder)
        {
            builder.HasOne(s => s.FirstPlayer).WithOne(_ => _.CurrentGameRoom);
            builder.HasOne(s => s.SecondPlayer).WithOne(_ => _.CurrentGameRoom);
            builder.HasMany(s => s.GameHistory).WithOne(_ => _.GameRoom);
        }
    }
}
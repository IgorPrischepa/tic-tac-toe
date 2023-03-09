using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicTacToeApi.Dal.Entities;

namespace TicTacToeApi.Dal.Db.Configs
{
    internal class GameRoomConfiguration : IEntityTypeConfiguration<GameRoomEntity>
    {
        public void Configure(EntityTypeBuilder<GameRoomEntity> builder)
        {
            builder.HasKey(_ => _.GameRoomId);
            builder.HasMany(s => s.GameHistory).WithOne(_ => _.GameRoom);
            builder.HasOne(u => u.FirstPlayer).WithMany(_ => _.Games);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicTacToeApi.Dal.Entities;

namespace TicTacToeApi.Dal.Db.Configs
{
    internal class PlayerTurnConfiguration : IEntityTypeConfiguration<PlayerTurnEntity>
    {
        public void Configure(EntityTypeBuilder<PlayerTurnEntity> builder)
        {
            builder.HasKey(_ => _.PlayerTurnId);
            builder.HasOne(_ => _.GameRoom).WithMany(_ => _.GameHistory).HasForeignKey(_ => _.GameRoomId);
            builder.HasOne(_ => _.Player).WithMany(_ => _.TurnsHistory).HasForeignKey(_ => _.PlayerId);
            builder.Property(_ => _.PlayerId).IsRequired();
            builder.Property(_ => _.Row).IsRequired();
            builder.Property(_ => _.Column).IsRequired();
        }
    }
}
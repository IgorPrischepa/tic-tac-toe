using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicTacToeApi.Dal.Entities;

namespace TicTacToeApi.Dal.Db.Configs
{
    internal class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.UserId);
            builder.Property(u => u.Email).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.NickName).IsRequired();
            builder.HasIndex(u => u.NickName).IsUnique();
            builder.Property(u => u.NickName).HasMaxLength(40);
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.HasMany(u => u.Roles).WithMany(_ => _.Users);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TicTacToeApi.Dal.Entities;

namespace TicTacToeApi.Dal.Db.Configs
{
    internal class RoleConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.Property(u => u.Name).IsRequired();
            builder.HasIndex(u => u.Name).IsUnique();
            builder.HasData(new RoleEntity() { Id = 1, Name = "Admin" });
            builder.HasData(new RoleEntity { Id = 2, Name = "Player" });
            builder.HasMany(u => u.Users);
        }
    }
}
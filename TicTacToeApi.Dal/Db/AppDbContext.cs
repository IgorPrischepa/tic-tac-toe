using Microsoft.EntityFrameworkCore;
using TicTacToeApi.Dal.Db.Configs;
using TicTacToeApi.Dal.Entities;

namespace TicTacToeApi.Dal.Db
{
    public sealed class AppDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; } = null!;

        public DbSet<RoleEntity> Roles { get; set; } = null!;

        public DbSet<GameRoomEntity> GameRooms { get; set; } = null!;

        public DbSet<PlayerTurnEntity> PlayerTurns { get; set; } = null!;

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new GameRoomConfiguration());
            modelBuilder.ApplyConfiguration(new PlayerTurnConfiguration());
        }
    }
}
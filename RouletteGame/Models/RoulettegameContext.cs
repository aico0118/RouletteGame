using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RouletteGame.Models
{
    public partial class RoulettegameContext : DbContext
    {
        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<Coin> Coin { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=roulettegame.cw1s7snxh3yp.ap-northeast-1.rds.amazonaws.com,1433;Initial Catalog=roulettegame;User ID=dbadmin;Password=a123456&");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.ToTable("card");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(8, 0)");

                entity.Property(e => e.CreDate)
                    .HasColumnName("cre_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(8, 0)");

                entity.Property(e => e.Reward)
                    .HasColumnName("reward")
                    .HasColumnType("decimal(8, 0)");

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upd_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Coin>(entity =>
            {
                entity.ToTable("coin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("decimal(8, 0)");

                entity.Property(e => e.CreDate)
                    .HasColumnName("cre_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upd_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("game");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Coin)
                    .HasColumnName("coin")
                    .HasColumnType("decimal(8, 0)");

                entity.Property(e => e.CreDate)
                    .HasColumnName("cre_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upd_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Game)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_game_room");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreDate)
                    .HasColumnName("cre_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasColumnName("creator")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.IsActive)
                    .HasColumnName("is_active")
                    .HasColumnType("char(1)");

                entity.Property(e => e.LimitUsers).HasColumnName("limit_users");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upd_date")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Coin)
                    .HasColumnName("coin")
                    .HasColumnType("decimal(8, 0)");

                entity.Property(e => e.CreDate)
                    .HasColumnName("cre_date")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20);

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.UpdDate)
                    .HasColumnName("upd_date")
                    .HasColumnType("datetime");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user_room");
            });
        }
    }
}

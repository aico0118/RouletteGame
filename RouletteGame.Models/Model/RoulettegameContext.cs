using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RouletteGame.Models.Model
{
    public partial class RoulettegameContext : DbContext
    {
        public virtual DbSet<CardConfig> CardConfig { get; set; }
        public virtual DbSet<CardConfigDetail> CardConfigDetail { get; set; }
        public virtual DbSet<CardType> CardType { get; set; }
        public virtual DbSet<Challenger> Challenger { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameBetDetail> GameBetDetail { get; set; }
        public virtual DbSet<GameConfig> GameConfig { get; set; }
        public virtual DbSet<Room> Room { get; set; }
        public virtual DbSet<RoomDetail> RoomDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=roulettegame.cw1s7snxh3yp.ap-northeast-1.rds.amazonaws.com;Initial Catalog=roulettegame;User ID=dbadmin;Password=a123456&");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardConfig>(entity =>
            {
                entity.ToTable("card_config");

                entity.Property(e => e.CardConfigId)
                    .HasColumnName("card_config_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.EffDateFrom)
                    .HasColumnName("eff_date_from")
                    .HasColumnType("datetime");

                entity.Property(e => e.EffDateTo)
                    .HasColumnName("eff_date_to")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<CardConfigDetail>(entity =>
            {
                entity.HasKey(e => new { e.CardTypeId, e.CardConfigId, e.Position });

                entity.ToTable("card_config_detail");

                entity.HasIndex(e => e.CardConfigId)
                    .HasName("IX_card_config_detail")
                    .IsUnique();

                entity.Property(e => e.CardTypeId).HasColumnName("card_type_id");

                entity.Property(e => e.CardConfigId).HasColumnName("card_config_id");

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<CardType>(entity =>
            {
                entity.ToTable("card_type");

                entity.Property(e => e.CardTypeId)
                    .HasColumnName("card_type_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasColumnName("color")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Reward)
                    .HasColumnName("reward")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Challenger>(entity =>
            {
                entity.ToTable("challenger");

                entity.Property(e => e.ChallengerId)
                    .HasColumnName("challenger_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ImageId).HasColumnName("image_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.RoomId });

                entity.ToTable("game");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .HasColumnType("nchar(10)");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_time")
                    .HasColumnType("datetime");

                entity.Property(e => e.GameConfigId).HasColumnName("game_config_id");

                entity.Property(e => e.Result)
                    .HasColumnName("result")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_time")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<GameBetDetail>(entity =>
            {
                entity.HasKey(e => new { e.ChallengerId, e.CardTypeId, e.GameId });

                entity.ToTable("game_bet_detail");

                entity.Property(e => e.ChallengerId).HasColumnName("challenger_id");

                entity.Property(e => e.CardTypeId).HasColumnName("card_type_id");

                entity.Property(e => e.GameId).HasColumnName("game_id");

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<GameConfig>(entity =>
            {
                entity.ToTable("game_config");

                entity.Property(e => e.GameConfigId)
                    .HasColumnName("game_config_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.DefaultCoinQuantity).HasColumnName("default_coin_quantity");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("room");

                entity.Property(e => e.RoomId)
                    .HasColumnName("room_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.MaxAllowPerson).HasColumnName("max_allow_person");

                entity.Property(e => e.RoomName)
                    .IsRequired()
                    .HasColumnName("room_name")
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<RoomDetail>(entity =>
            {
                entity.HasKey(e => new { e.RoomId, e.ChallengerId });

                entity.ToTable("room_detail");

                entity.Property(e => e.RoomId).HasColumnName("room_id");

                entity.Property(e => e.ChallengerId).HasColumnName("challenger_id");
            });
        }
    }
}

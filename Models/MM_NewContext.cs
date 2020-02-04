using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MM_Ang.Models
{
    public partial class MM_NewContext : DbContext
    {
        public MM_NewContext()
        {
        }

        public MM_NewContext(DbContextOptions<MM_NewContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<DeviceCodes> DeviceCodes { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventAddress> EventAddress { get; set; }
        public virtual DbSet<EventStatus> EventStatus { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<EventUpdate> EventUpdate { get; set; }
        public virtual DbSet<PersistedGrants> PersistedGrants { get; set; }
        public virtual DbSet<TimeZoneInfo> TimeZoneInfo { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-O1L7UM7;Database=MM_New;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<DeviceCodes>(entity =>
            {
                entity.HasKey(e => e.UserCode);

                entity.HasIndex(e => e.DeviceCode)
                    .IsUnique();

                entity.HasIndex(e => e.Expiration);

                entity.Property(e => e.UserCode).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.DeviceCode)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SubjectId).HasMaxLength(200);
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.Property(e => e.EventDate).HasColumnType("date");

                entity.Property(e => e.EventLocationDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventLocationLat).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EventLocationLong).HasColumnType("numeric(18, 6)");

                entity.Property(e => e.EventNotes)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EventShortDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EventSourceLink)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventAddress>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AddressCity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressLine2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AddressStateCode)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.AddressZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FullGoogleAddress)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("numeric(10, 6)");

                entity.Property(e => e.Longitude).HasColumnType("numeric(10, 6)");
            });

            modelBuilder.Entity<EventStatus>(entity =>
            {
                entity.Property(e => e.StatusDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.Property(e => e.ActiveFlag)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.EventIconName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EventTypeDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<EventUpdate>(entity =>
            {
                entity.Property(e => e.UpdateDesc)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.EventUpdate)
                    .HasForeignKey(d => d.EventId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventUpdate_Event");

                entity.HasOne(d => d.EventStatus)
                    .WithMany(p => p.EventUpdate)
                    .HasForeignKey(d => d.EventStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventUpdate_Status");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.EventUpdate)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EventUpdate_User");
            });

            modelBuilder.Entity<PersistedGrants>(entity =>
            {
                entity.HasKey(e => e.Key);

                entity.HasIndex(e => e.Expiration);

                entity.HasIndex(e => new { e.SubjectId, e.ClientId, e.Type });

                entity.Property(e => e.Key).HasMaxLength(200);

                entity.Property(e => e.ClientId)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Data).IsRequired();

                entity.Property(e => e.SubjectId).HasMaxLength(200);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TimeZoneInfo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DisplayName).HasMaxLength(255);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.RunHourUtc).HasColumnName("RunHour-UTC");

                entity.Property(e => e.TimeZoneId).HasMaxLength(255);
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserProf__1788CC4CDAFB4B07");

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__UserProf__C9F28456AAA0AFB5")
                    .IsUnique();

                entity.Property(e => e.Address1)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Address2)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone1)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Phone2)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Phone3)
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.PreferredContactMethod)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(56);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

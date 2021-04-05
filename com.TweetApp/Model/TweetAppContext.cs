using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace com.TweetApp.Model
{
    public partial class TweetAppContext : DbContext
    {
        public TweetAppContext()
        {
        }

        public TweetAppContext(DbContextOptions<TweetAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Registration> Registrations { get; set; }
        public virtual DbSet<Tweet> Tweets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAB-63752422077;Database=TweetApp;User id=sa;Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__Registra__7ED91ACFAB1DE3E5");

                entity.ToTable("Registration");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Passcode)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tweet>(entity =>
            {
                entity.HasKey(e => e.EmailId)
                    .HasName("PK__Tweet__7ED91ACF382A1937");

                entity.ToTable("Tweet");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.TweetMessage)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TweetTime).HasColumnType("datetime");

                entity.HasOne(d => d.Email)
                    .WithOne(p => p.Tweet)
                    .HasForeignKey<Tweet>(d => d.EmailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Tweet__EmailId__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

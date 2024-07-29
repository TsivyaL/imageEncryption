using Microsoft.EntityFrameworkCore;

namespace MODELS.Model
{
    public partial class DBContext : DbContext
    {
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public  DbSet<User> Users { get; set; } 
        public  DbSet<Picture> Pictures { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-F77S003\\SQLEXPRESS01;Initial Catalog=ImageEncryption2;Integrated Security=SSPI;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.HasMany(u => u.UserPictures)
                      .WithOne(p => p.User)
                      .HasForeignKey(p => p.UserId)  
                      .OnDelete(DeleteBehavior.Cascade);
                entity.Property(e => e.Id).UseIdentityColumn();
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.ToTable("Picture");
                entity.Property(e => e.Id).UseIdentityColumn();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

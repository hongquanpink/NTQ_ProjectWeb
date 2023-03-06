using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DAL_Data_Access_Layer_.EF
{
    public partial class QLBanHangDbContext : DbContext
    {
        public QLBanHangDbContext()
            : base("name=QLBanHangDbContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Reviews> Reviews { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WishList> WishList { get; set; }
        public virtual DbSet<Medias> Medias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CategoryName)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.Detail)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .Property(e => e.MetaKey)
                .IsUnicode(false);

            modelBuilder.Entity<Products>()
                .HasMany(e => e.Reviews)
                .WithOptional(e => e.Products)
                .HasForeignKey(e => e.ProductID);

            modelBuilder.Entity<Reviews>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<WishList>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Medias>()
                .Property(e => e.Path)
                .IsUnicode(false);
        }
    }
}

using ErisCakesWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ErisCakesWebApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<BakeryRequest> BakeryRequests { get; set; }
        public DbSet<BakeryRecipe> BakeryRecipes { get; set; }
        public DbSet<BakeryRequestRecipe> BakeryRequestRecipes { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BakeryRequest>(entity =>
            {
                entity.ToTable("BakeryRequests");

                entity.HasOne(br => br.Client)
                .WithMany(br => br.BakeryRequests)
                .HasForeignKey(br => br.ClientId)
                .HasConstraintName("FK_BakeryRequest_Client");
            });

            modelBuilder.Entity<BakeryRequestRecipe>(entity =>
            {
                entity.HasKey(brr => new {brr.BakeryRequestId, brr.BakeryRecipeId });

                entity.ToTable("BakeryRequestRecipes");

                entity.HasOne(brr => brr.BakeryRequest)
                .WithMany(brr => brr.BakeryRequestRecipes)
                .HasForeignKey(brr => brr.BakeryRequestId)
                .HasConstraintName("FK_BakeryRequestRecipe_BakeryRequest");

                entity.HasOne(brr => brr.BakeryRecipe)
                .WithMany(brr => brr.BakeryRequestRecipes)
                .HasForeignKey(brr => brr.BakeryRecipeId)
                .HasConstraintName("FK_BakeryRequestRecipe_BakeryRecipe");
            });

            modelBuilder.Entity<BakeryRecipe>(entity =>
            {
                entity.ToTable("BakeryRecipes");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("Clients");
            });
             
            base.OnModelCreating(modelBuilder);
        }
    }
}

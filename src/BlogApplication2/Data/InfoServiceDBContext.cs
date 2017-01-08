using BlogApplication2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogApplication2.Data
{
    public class InfoServiceDBContext : DbContext
    {
        public InfoServiceDBContext(DbContextOptions<InfoServiceDBContext> options) : base(options)
        {
        }

        public DbSet<EmailProviderInformation> EmailProviderInformation { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmailProviderInformation>().ToTable("EmailProviderInformation");
        }
    }
}
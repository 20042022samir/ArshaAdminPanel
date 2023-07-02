using ArshaAdminPanel.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace ArshaAdminPanelll.Context
{
    public class ArshaDbContext:DbContext
    {
        public DbSet<Positionn> jobsposition { get; set; }
        public DbSet<Employees> employees { get; set; }
        public  DbSet<SocialMedia> socialMedias { get; set; }   
        public ArshaDbContext(DbContextOptions<ArshaDbContext> options):base(options)
        {

        }
    }
}

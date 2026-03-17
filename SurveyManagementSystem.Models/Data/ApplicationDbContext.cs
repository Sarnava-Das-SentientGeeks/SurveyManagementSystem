using Microsoft.EntityFrameworkCore;
using SurveyManagementSystem.BLL.Entities;



namespace SurveyManagementSystem.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }



        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //   modelBuilder.Entity<User>()
        //        .HasMany(e=>e.Users)
        //}
      
    }
}

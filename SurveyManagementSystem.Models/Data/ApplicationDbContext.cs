using Microsoft.EntityFrameworkCore;
using SurveyManagementSystem.BLL.Entities;


namespace SurveyManagementSystem.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<User> User { get; set; }

       

    }
}

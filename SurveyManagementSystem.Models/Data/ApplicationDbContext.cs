using Microsoft.EntityFrameworkCore;
using SurveyManagementSystem.BLL.Entities;



namespace SurveyManagementSystem.DAL.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

        public DbSet<User> User { get; set; }

        public DbSet<Role> Role { get; set; }

        public DbSet<Survey> Survey { get; set; }

        public DbSet<Questions> Questions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //1)Survey → Questions → Answers
            //2)Survey → Responses → Answers
            //SQL Server does not allow multiple cascade paths pointing to the same table(Answers) so break one path i.e Survey → Questions → Answers

            //Fluent API for all 1-N relationships
            ///////////////////////////////////////////////////////////

            modelBuilder.Entity<User>()
                .HasMany(e => e.Responses)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired();
///////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Survey>()
                .HasMany(e => e.Questions)
                .WithOne(e => e.Survey)
                .HasForeignKey(e => e.SurveyId)
                .IsRequired();

            modelBuilder.Entity<Survey>()
               .HasMany(e => e.Responses)
               .WithOne(e => e.Survey)
               .HasForeignKey(e => e.SurveyId)
               .IsRequired();
            ////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Questions>()
                .HasMany(e => e.Answers)
                .WithOne(e => e.Questions)
                .HasForeignKey(e => e.QuestionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);//Breaking cascade path
            


            modelBuilder.Entity<Questions>()
               .HasMany(e => e.Options)
               .WithOne(e => e.Questions)
               .HasForeignKey(e => e.QuestionId)
               .IsRequired();
/////////////////////////////////////////////////////////////////////
            modelBuilder.Entity<Response>()
             .HasMany(e => e.Answers)
             .WithOne(e => e.Response)
             .HasForeignKey(e => e.ResponseId)
             .IsRequired()
             .OnDelete(DeleteBehavior.NoAction); //Breaking cascade path



        }

    }
}

using Microsoft.EntityFrameworkCore;
using Quiz.Models.Models;
using QuizApp.Model.Models;
using System.Diagnostics;

namespace QuizModels.Models
{
    public class QuizAppContext : DbContext
    {
        public QuizAppContext(DbContextOptions<QuizAppContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>()
                    .HasOne<Question>(s => s.Question)
                    .WithMany(g => g.Answers)
                    .HasForeignKey(s => s.QuestionId);

            modelBuilder.Entity<ResultAnswer>()
                    .HasOne<Result>(s => s.Result)
                    .WithMany(g => g.ResultAnswer)
                    .HasForeignKey(s => s.ResultId);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultAnswer> ResultAnswers { get; set; }
        
    }
}
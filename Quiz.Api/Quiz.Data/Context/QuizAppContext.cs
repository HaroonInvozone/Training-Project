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
            modelBuilder.Entity<ResultAnswer>()
                    .HasOne<Question>(s => s.Question)
                    .WithMany(g => g.ResultAnswer)
                    .HasForeignKey(s => s.Question_Id);
            //modelBuilder.Entity<ResultAnswer>()
            //        .HasOne<Answer>(s => s.Answer)
            //        .WithMany(g => g.ResultAnswer)
            //        .HasForeignKey(s => s.Answer);
            modelBuilder.Entity<ResultAnswer>()
                    .HasOne<Result>(s => s.Result)
                    .WithMany(g => g.ResultAnswer)
                    .HasForeignKey(s => s.Result_Id);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultAnswer> ResultAnswers { get; set; }
        
    }
}
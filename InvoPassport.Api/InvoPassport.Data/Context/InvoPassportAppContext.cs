using InvoPassport.Model.Models;
using InvoPassport.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoPassport.Models
{
    public class InvoPassportAppContext : DbContext
    {
        public InvoPassportAppContext(DbContextOptions<InvoPassportAppContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>(x =>
            {
                x.ToTable(nameof(Users));
                x.HasKey(x => x.Id);
                x.Property(p => p.FirstName);
                x.Property(p => p.lastName);
                x.Property(p => p.Email);
                x.Property(p => p.JobTitle);
                x.Property(p => p.Role);
                x.Property(p => p.IsRevoke);
                x.Property(p => p.IsVerified);
                x.Property(p => p.CreatedOn);
                x.Property(p => p.PassId);
                x.Property(p => p.PassportExpiry);
                x.Property(p => p.PasswordHash);
                x.Property(p => p.PasswordSalt);
                x.Property(p => p.RefreshToken);
                x.Property(p => p.TokenCreated);
                x.Property(p => p.TokenExpires);
                x.HasMany(x => x.Result);
            });
            modelBuilder.Entity<Question>(x =>
            {
                x.ToTable(nameof(Question));
                x.HasKey(x => x.Id);
                x.Property(p => p.Id);
                x.Property(p => p.Number);
                x.Property(p => p.Title);
                x.HasMany(a => a.Answers);
            });

            modelBuilder.Entity<Answer>(x =>
            {
                x.ToTable(nameof(Answer));
                x.HasKey(x => x.Id);
                x.Property(p => p.Option);
                x.Property(p => p.IsCorrect);
                x.Property(p => p.QuestionId);
                x.HasOne(a => a.Question);
            });

            modelBuilder.Entity<Result>(x =>
            {
                x.ToTable(nameof(Result));
                x.HasKey(x => x.Id);
                x.Property(x => x.Test_Date);
                x.Property(x => x.StartTime);
                x.Property(x => x.EndTime);
                x.Property(x => x.CorrectAnswer);
                x.Property(x => x.TotalQuestion);
                x.Property(x => x.CurrentState);
                x.Property(x => x.UserId);
                x.HasOne(x => x.User);
                x.HasMany(x => x.ResultAnswer);
            });
            modelBuilder.Entity<ResultAnswer>(x =>
            {
                x.ToTable(nameof(ResultAnswer));
                x.HasKey(x => x.Id);
                x.Property(x => x.QuestionId);
                x.Property(x => x.AnswerId);
                x.Property(x => x.ResultId);
                x.HasOne(p => p.Question);
                x.HasOne(p => p.Answer);
                x.HasOne(p => p.Result);
            });

            //modelBuilder.Entity<Answer>()
            //        .HasOne<Question>(s => s.Question)
            //        .WithMany(g => g.Answers)
            //        .HasForeignKey(s => s.QuestionId);

            //modelBuilder.Entity<ResultAnswer>()
            //        .HasOne<Result>(s => s.Result)
            //        .WithMany(g => g.ResultAnswer)
            //        .HasForeignKey(s => s.ResultId);
        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<ResultAnswer> ResultAnswers { get; set; }
        
    }
}
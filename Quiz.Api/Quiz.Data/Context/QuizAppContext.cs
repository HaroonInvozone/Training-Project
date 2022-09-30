using Microsoft.EntityFrameworkCore;
using QuizApp.Model.Models;

namespace QuizModels.Models
{
    public class QuizAppContext : DbContext
    {
        public QuizAppContext(DbContextOptions<QuizAppContext> options)
            : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
    }
}
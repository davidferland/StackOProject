using System.Linq;
using Microsoft.EntityFrameworkCore;
using StackO.Core.Models;
namespace StackO.Data.Context {
    public class StackODBContext : DbContext {
        public StackODBContext (DbContextOptions<StackODBContext> options) : base (options) {
            Database.Migrate ();
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }

    }
}
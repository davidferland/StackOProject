using System.Linq;
using Microsoft.EntityFrameworkCore;
using StackO.Domain.Entities;

namespace StackO.Data.Infrastructure {
    public class StackODBContext : DbContext {
        public StackODBContext (DbContextOptions<StackODBContext> options) : base (options) {
            Database.Migrate ();
        }

        public DbSet<Answer> Answers { get; set; }
        public DbSet<Question> Questions { get; set; }

    }
}
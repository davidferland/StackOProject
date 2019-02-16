using Microsoft.EntityFrameworkCore;

namespace StackO.Data.Context {
    public class TemporaryDbContextFactory : DesignTimeDbContextFactoryBase<StackODBContext> {
        protected override StackODBContext CreateNewInstance (
            DbContextOptions<StackODBContext> options) {
            return new StackODBContext (options);
        }
    }
}
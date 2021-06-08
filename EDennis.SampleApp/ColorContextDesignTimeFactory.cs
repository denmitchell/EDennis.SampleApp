using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EDennis.SampleApp {
    public class ColorContextDesignTimeFactory
        : IDesignTimeDbContextFactory<ColorContext>
    {
        public ColorContext CreateDbContext(string[] args)
        {
            var cxnString = $"Server=(localdb)\\MSSQLLocalDB;Database=ColorContext;" +
                $"Trusted_Connection=True;MultipleActiveResultSets=True;";

            var options = new DbContextOptionsBuilder<ColorContext>()
                .UseSqlServer(cxnString)
                .Options;

            var ctx = new ColorContext(options);

            return ctx;
        }
    }


}

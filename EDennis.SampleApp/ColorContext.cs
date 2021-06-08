using Microsoft.EntityFrameworkCore;

namespace EDennis.SampleApp
{

    public class ColorContext : DbContext
    {

        public ColorContext(DbContextOptions<ColorContext> options)
            : base(options) { }

        public virtual DbSet<Rgb> Rgb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.HasSequence<int>("seqRgb")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder
                .Entity<Rgb>(e => {

                    e.ToTable("Rgb");
                    e.HasKey(p => p.Id);

                    e.Property(p => p.Id)
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("NEXT VALUE FOR seqRgb");

                });

        }


    }
}

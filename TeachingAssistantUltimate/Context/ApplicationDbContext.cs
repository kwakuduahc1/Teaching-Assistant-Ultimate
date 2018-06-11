using Microsoft.EntityFrameworkCore;
using TeachingAssistant.Model;

namespace TeachingAssistant.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=assistant.db;", x =>
            {
                x.SuppressForeignKeyEnforcement(false);
                x.UseRelationalNulls(true);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Subjects>(x => x.HasData(
                new Subjects { Subject = "Public Health Nursing", SubjectsID = 1 },
                new Subjects { Subject = "Basic Infection Prevention and Control", SubjectsID = 2 }
                ));
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.// For example, you can rename the ASP.NET Identity table names and more.// Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Questions> Questions { get; set; }

        public virtual DbSet<Subjects> Subjects { get; set; }

        public virtual DbSet<Options> Options { get; set; }
    }
}

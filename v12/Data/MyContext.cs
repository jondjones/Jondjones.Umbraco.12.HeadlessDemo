using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace v12.Data {
    public class MyContext : DbContext {

        protected readonly IConfiguration Configuration;

        public MyContext(
            DbContextOptions<MyContext> options,
            IConfiguration configuration) : base(options) {
            Configuration = configuration;

        }

        public required DbSet<CustomUsers> CustomUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            modelBuilder.Entity<CustomUsers>(entity => {
                entity.ToTable("customUsers");
                entity.HasKey(e => e.Name);
                entity.Property(e => e.Name).HasColumnName("name");
                entity.Property(e => e.Surname).HasColumnName("surname");

                // .Property(s => s.Id).HasDatabaseGeneratedOption
            });

        // DO NOT USE
        //protected override void OnConfiguring(DbContextOptionsBuilder options) {

        //    //dotnet ef database update
        //    options.UseSqlite(Configuration.GetConnectionString("umbracoDbDSN"));
        //}
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace v12.Data;

public class MyContext : DbContext {

    public MyContext(
        DbContextOptions<MyContext> options) : base(options) {
    }

    public required DbSet<CustomUser> CustomUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>

        modelBuilder.Entity<CustomUser>(entity => {
            entity.ToTable("customUsers");
            entity.HasKey(e => e.Name);
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Surname).HasColumnName("surname");
        });










    // DO NOT USE
    //protected override void OnConfiguring(DbContextOptionsBuilder options) {
    //    //dotnet ef database update
    //    options.UseSqlite(Configuration.GetConnectionString("umbracoDbDSN"));
    //}
}

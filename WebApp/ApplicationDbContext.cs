using Microsoft.EntityFrameworkCore;

namespace WebApp;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString = "Host=localhost;Username=postgres;Password=123;Database=postgres";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(_connectionString);
    }

    public DbSet<Model.People> People  { get; set; }
    public DbSet<Model.PhoneBook> PhoneBook { get; set; }

    //видео 1 : 00
}
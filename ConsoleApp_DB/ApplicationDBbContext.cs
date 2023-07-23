using Microsoft.EntityFrameworkCore;
namespace ConsoleApp_DB;

public class ApplicationDBbContext : DbContext
{
    private readonly string _connectionString =  "Host=localhost;Username=postgres;Password=123;Database=postgres";
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(_connectionString);
    }

    public DbSet<Model.PhoneBook > PhoneBook { get; set; }
    
    //видео 1 : 00
}
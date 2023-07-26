using Microsoft.EntityFrameworkCore;
using Self_burning_message.Models;
namespace Self_burning_message;

public class ApplicationDbContext : DbContext
{
    private readonly string _connectionString = "Host=localhost;Username=postgres;Password=123;Database=postgres";

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(_connectionString);
    }

    public DbSet<Message> messages  { get; set; }
   
    //видео 1 : 00
}
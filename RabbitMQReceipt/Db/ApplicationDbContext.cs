using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<Produto> Produtos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=srv.allanlf.com.br,1433;Database=AppRabbitMQ;User ID=appRabbit;Password=Ac2245678;Trusted_Connection=False; TrustServerCertificate=True;");
    }
}
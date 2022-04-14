using Card_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Card_Api.Data;

public class CardsDbContext: DbContext
{
    public CardsDbContext(DbContextOptions options): base(options)
    {
    }
    
    // DbSet
    public DbSet<Card> Cards { get; set; }
}
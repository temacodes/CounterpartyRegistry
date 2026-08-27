using Microsoft.EntityFrameworkCore;
using CounterpartyRegistry.Models;

namespace CounterpartyRegistry;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Counterparty> Counterparties => Set<Counterparty>();
}
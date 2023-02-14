using olxapi.Models;
using Microsoft.EntityFrameworkCore;

namespace olxapi.Data;

public class OlxContext : DbContext
{
    public OlxContext(DbContextOptions<OlxContext> options) 
        : base(options)
    {

    }
    public DbSet<Ad> Ads { get; set; }    
}

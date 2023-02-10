using olxapi.Models;
using Microsoft.EntityFrameworkCore;

namespace AdApi.Data;

public class AdContext : DbContext
{
    public AdContext(DbContextOptions<AdContext> options) 
        : base(options)
    {

    }
    public DbSet<Ad> Ads { get; set; }    
}

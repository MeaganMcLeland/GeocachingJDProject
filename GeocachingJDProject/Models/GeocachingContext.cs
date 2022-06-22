using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace GeocachingJDProject.Models
{
    public class GeocachingContext : DbContext
    {
        public GeocachingContext (DbContextOptions<GeocachingContext> options)
            :base(options)
        {

        }

        public DbSet<GeocachingContainers> GeocachingContainer { get; set; } = null!;

        public DbSet<GeocachingItems> GeocachingItem { get; set; } = null!;

    }
}

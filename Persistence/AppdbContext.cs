
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domani;

namespace Persistence
{
    public class AppdbContext(DbContextOptions options) : DbContext(options)
    {
        public required DbSet<Activity> Activities { get; set; }
    }
}
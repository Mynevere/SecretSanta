using Microsoft.EntityFrameworkCore;
using SecretSanta.Models;

namespace SecretSanta.DAL
{
    public class SecretSantaContext:DbContext
    {
        public SecretSantaContext()
        {

        }
        public SecretSantaContext(DbContextOptions<SecretSantaContext> options)
            : base(options)
        {
        }

        public DbSet<Participants>  Participants{ get; set; }

        
    }
}

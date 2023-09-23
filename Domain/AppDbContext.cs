using Microsoft.EntityFrameworkCore;
using SchiaviDelPadel.Domain.Models;

namespace SchiaviDelPadel.Domain
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
    }
}

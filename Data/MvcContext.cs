
using Microsoft.EntityFrameworkCore;
using MVC03.Models;

namespace MVC03.Data
{
    public class MvcContext : DbContext
    {
        public MvcContext(DbContextOptions<MvcContext> options)
            : base(options)
        {
        }

        public DbSet<Member> tblMember { get; set; } = default!;
    }
}

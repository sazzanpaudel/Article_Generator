using MVC_Article.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace MVC_Article.Data
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<T_data> Datas { get; set; }
    }
}

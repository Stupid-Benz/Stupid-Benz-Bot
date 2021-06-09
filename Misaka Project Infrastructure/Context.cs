using Microsoft.EntityFrameworkCore;

namespace Misaka_Project_Infrastructure
{
    public class Context : DbContext
    {
        public DbSet<Server> Servers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseMySql("server=localhost;user=root;database=misaka project;port=3306;Connect timeout=5;");
    }

    public class Server
    {
        public ulong Id { get; set; }
        public string Prefix { get; set; }
    }
}

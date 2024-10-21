using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Vitrino.API.Database
{
    public class ContextInterpreter
    {
        private SqliteContext _ctx;

        private ContextInterpreter(SqliteContext ctx)
        {
            _ctx = ctx;
        }

        public static ContextInterpreter Get(SqliteContext ctx)
        {
            return new(ctx);
        }
    }

    public class SqliteContext : DbContext
    {
        public DbSet<UserContext> Users { get; set; }
        public DbSet<ImageContext> Images { get; set; }
        public DbSet<CharacterContext> Characters { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=Sqlite.db");
    }

    public class CharacterContext
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public ulong Id { set; get; }
        public string Name { set; get; }
    }

    public class UserContext
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public ulong Id { set; get; }
        public string Name { set; get; }
    }

    public class ImageContext
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] public ulong Id { set; get; }
        public bool IsNsfw { set; get; }
        public UserContext User { set; get; }
        public CharacterContext Character { set; get; }
        public string Title { set; get; }
    }
}

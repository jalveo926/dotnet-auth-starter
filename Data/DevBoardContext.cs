using DevBoard.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevBoard.Data
{
    public class DevBoardContext : DbContext
    {
        // Constructor que recibe las opciones de configuración del contexto
        public DevBoardContext(DbContextOptions<DevBoardContext> options)
            : base(options)
        {
        }

        // Entidades que se mapearán a tablas
        public DbSet<User> Users { get; set; }
    }
}
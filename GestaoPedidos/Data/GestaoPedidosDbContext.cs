using GestaoPedidos.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GestaoPedidos.Data
{
    public class GestaoPedidosDbContext : DbContext
    {
        public GestaoPedidosDbContext(DbContextOptions<GestaoPedidosDbContext> options)
        : base(options)
        {
        }

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> Items { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("DataSource=app.db;Cache=Shared");
            }
        }
    }
}

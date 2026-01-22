using GestaoPedidos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedidos.Data.Mapping
{
    public class PedidoMap : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            // Table
            builder.ToTable("Pedido");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            // Properties
            builder.Property(x => x.ClienteNome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.DataCriacao)
                .IsRequired();

            builder.Property(x => x.Status)
                .IsRequired();

            builder.Property(x => x.ValorTotal)
                .IsRequired();

            // Relationships
            builder
                .HasMany(x => x.Items)
                .WithOne(x => x.Pedido)
                .HasConstraintName("FK_Pedido_ItemPedido")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

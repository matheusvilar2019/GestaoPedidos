using GestaoPedidos.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoPedidos.Data.Mapping
{
    public class ItemPedidoMap : IEntityTypeConfiguration<ItemPedido>
    {
        public void Configure(EntityTypeBuilder<ItemPedido> builder)
        {
            // Table
            builder.ToTable("ItemPedido");

            // Primary Key
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            // Properties
            builder.Property(x => x.ProdutoNome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(x => x.Quantidade)
                .IsRequired();

            builder.Property(x => x.PrecoUnitario)
                .IsRequired();
        }
    }
}

using GestaoPedidos.Models.Entities;
using GestaoPedidos.Models.Enums;
using GestaoPedidos.Tests.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPedidos.Tests
{
    public class PedidoTests : DbContextTestBase
    {
        [Fact]
        public async Task CriarPedido_ComItensValidos_DeveCalcularValorTotal()
        {
            // Arrange
            var context = CreateContext();

            var pedido = new Pedido
            {
                ClienteNome = "Matheus",
                Status = PedidoStatus.Novo,
                DataCriacao = DateTime.Now,
                Items = new List<ItemPedido>
            {
                new ItemPedido
                {
                    ProdutoNome = "Produto A",
                    Quantidade = 2,
                    PrecoUnitario = 10
                },
                new ItemPedido
                {
                    ProdutoNome = "Produto B",
                    Quantidade = 1,
                    PrecoUnitario = 20
                }
            }
            };

            pedido.ValorTotal = pedido.Items.Sum(i => i.Quantidade * i.PrecoUnitario);

            // Act
            context.Pedidos.Add(pedido);
            await context.SaveChangesAsync();

            // Assert
            var pedidoSalvo = context.Pedidos.Include(p => p.Items).First();

            Assert.Equal(40, pedidoSalvo.ValorTotal);
            Assert.Equal(2, pedidoSalvo.Items.Count);
        }
    }
}

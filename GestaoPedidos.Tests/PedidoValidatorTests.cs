using GestaoPedidos.DTOs;
using GestaoPedidos.Models.Entities;
using GestaoPedidos.Models.Enums;
using GestaoPedidos.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoPedidos.Tests
{
    public class PedidoValidatorTests
    {
        [Fact]
        public void PedidoSemItens_DeveRetornarErro()
        {
            // Arrange
            var validator = new PedidoCreateDTOValidator();

            var dto = new PedidoCreateDTO
            {
                ClienteNome = "Matheus",
                Items = new List<ItemPedidoCreateDTO>()
            };

            // Act
            var result = validator.Validate(dto);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains(result.Errors, e => e.PropertyName == "Items");
        }

        [Fact]
        public void Cancelar_PedidoPago_DeveLancarExcecao()
        {
            // Arrange
            var pedido = new Pedido
            {
                Status = PedidoStatus.Pago
            };

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => pedido.Cancelar());
        }
    }
}

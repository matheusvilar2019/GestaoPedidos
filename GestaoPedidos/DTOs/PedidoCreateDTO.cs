using GestaoPedidos.Models.Entities;
using GestaoPedidos.Models.Enums;

namespace GestaoPedidos.DTOs
{
    public class PedidoCreateDTO
    {
        public string? ClienteNome { get; set; }
        public ICollection<ItemPedidoCreateDTO> Items { get; set; } = new List<ItemPedidoCreateDTO>();
    }
}

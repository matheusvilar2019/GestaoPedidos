using GestaoPedidos.Models.Enums;

namespace GestaoPedidos.DTOs
{
    public class PedidoResponseDTO
    {
        public Guid Id { get; set; }
        public string ClienteNome { get; set; } = null!;
        public DateTime DataCriacao { get; set; }
        public PedidoStatus Status { get; set; }
        public decimal ValorTotal { get; set; }
        public List<ItemPedidoResponseDTO> Items { get; set; } = [];
    }
}

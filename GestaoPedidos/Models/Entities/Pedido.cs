using GestaoPedidos.Models.Enums;

namespace GestaoPedidos.Models.Entities
{
    public class Pedido
    {
        public Guid Id { get; set; }
        public string ClienteNome { get; set; }
        public DateTime DataCriacao { get; set; }
        public PedidoStatus Status { get; set; }
        public decimal ValorTotal { get; set; }
        public ICollection<ItemPedido> Items { get; set; } = new List<ItemPedido>();

        public void Cancelar()
        {
            if (Status == PedidoStatus.Pago)
                throw new InvalidOperationException("Pedido pago não pode ser cancelado.");

            Status = PedidoStatus.Cancelado;
        }
    }
}

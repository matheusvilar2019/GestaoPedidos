using GestaoPedidos.Models.Enums;

namespace GestaoPedidos.Controllers
{
    internal class RetornaPedidoDto
    {
        public Guid Id { get; set; }
        public string ClienteNome { get; set; }
        public DateTime DataCriacao { get; set; }
        public PedidoStatus Status { get; set; }
        public decimal ValorTotal { get; set; }
        public object Items { get; set; }
    }
}
namespace GestaoPedidos.DTOs
{
    public class ItemPedidoResponseDTO
    {
        public string ProdutoNome { get; set; } = null!;
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}

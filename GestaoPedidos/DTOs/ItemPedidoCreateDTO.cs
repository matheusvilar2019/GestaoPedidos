namespace GestaoPedidos.DTOs
{
    public class ItemPedidoCreateDTO
    {
        public string? ProdutoNome { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}

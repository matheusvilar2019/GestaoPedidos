using AutoMapper;
using GestaoPedidos.DTOs;
using GestaoPedidos.Models.Entities;

namespace GestaoPedidos.Mappings
{
    public class PedidoProfile : Profile
    {
        public PedidoProfile()
        {
            CreateMap<PedidoCreateDTO, Pedido>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.DataCriacao, opt => opt.Ignore())
                .ForMember(dest => dest.ValorTotal, opt => opt.Ignore());

            CreateMap<ItemPedidoCreateDTO, ItemPedido>();

            CreateMap<Pedido, PedidoResponseDTO>();
            CreateMap<ItemPedido, ItemPedidoResponseDTO>();
        }
    }
}

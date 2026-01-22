using FluentValidation;
using GestaoPedidos.DTOs;

namespace GestaoPedidos.Validators
{

    public class ItemPedidoCreateDTOValidator : AbstractValidator<ItemPedidoCreateDTO>
    {
        public ItemPedidoCreateDTOValidator()
        {
            RuleFor(x => x.ProdutoNome)
                .NotEmpty()
                .WithMessage("ProdutoNome é obrigatório.");

            RuleFor(x => x.Quantidade)
                .GreaterThan(0)
                .WithMessage("Quantidade deve ser maior que zero.");

            RuleFor(x => x.PrecoUnitario)
                .GreaterThan(0)
                .WithMessage("PrecoUnitario deve ser maior que zero.");
        }
    }

}

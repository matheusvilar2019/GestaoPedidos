using FluentValidation;
using GestaoPedidos.DTOs;

namespace GestaoPedidos.Validators
{

    public class PedidoCreateDTOValidator : AbstractValidator<PedidoCreateDTO>
    {
        public PedidoCreateDTOValidator()
        {
            RuleFor(x => x.ClienteNome)
                .NotEmpty()
                .WithMessage("ClienteNome é obrigatório.");
    
            RuleFor(x => x.Items)
                .NotNull()
                .Must(x => x.Any())
                .WithMessage("O pedido deve conter ao menos um item.");
    
            RuleForEach(x => x.Items)
                .SetValidator(new ItemPedidoCreateDTOValidator());
        }
    }
}
using FluentValidation;
using MegaFilmes.Domain.Dtos.GeneroDto;

namespace MegaFilmes.Domain.Validations;

public class CreateGeneroValidation : AbstractValidator<CreateGeneroDto>
{
	public CreateGeneroValidation()
	{
        RuleFor(x => x.Nome)
        .NotEmpty()
        .NotNull();
    }
}

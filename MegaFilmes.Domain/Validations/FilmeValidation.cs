using FluentValidation;
using MegaFilmes.Domain.Dtos.FilmeDto;

namespace MegaFilmes.Domain.Validations;

public class CreateFilmeValidation : AbstractValidator<CreateFilmeDto>
{
	public CreateFilmeValidation()
	{
		RuleFor(x => x.Nome)
			.NotEmpty()
			.NotNull();

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Ano)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Diretor)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Genero)
            .NotEmpty()
            .NotNull();
    }
}

public class UpdateFilmeValidation : AbstractValidator<UpdateFilmeDto>
{
    public UpdateFilmeValidation()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Descricao)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Ano)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Diretor)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Genero)
            .NotEmpty()
            .NotNull();
    }
}
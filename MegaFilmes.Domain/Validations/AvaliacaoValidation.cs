using FluentValidation;
using MegaFilmes.Domain.Dtos.AvaliacaoDto;

namespace MegaFilmes.Domain.Validations;

public class CreateAvaliacaoValidation : AbstractValidator<CreateAvaliacaoDto>
{
    public CreateAvaliacaoValidation()
    {
        RuleFor(x => x.Criterio)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(1).LessThanOrEqualTo(5).WithMessage("O critério deve ter um valor entre 1 e 5.")
            .Must(x => x % 1 == 0).WithMessage("O critério deve ser inteiro.");

        RuleFor(x => x.Comentario)
            .MaximumLength(200).WithMessage("O comentário não pode ter mais do que 200 caracteres.");

        RuleFor(x => x.FilmeId)
            .NotEmpty()
            .NotNull();
    }
}
using FluentValidation;
using MegaFilmes.Domain.Dtos.FilmeAtorDto;

namespace MegaFilmes.Domain.Validations;

public class CreateFilmeAtorValidation : AbstractValidator<CreateFilmeAtorDto>
{
    public CreateFilmeAtorValidation()
    {
        RuleFor(x => x.FilmeId)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.AtorId)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.Papel)
            .NotEmpty()
            .NotNull();
    }
}

public class UpdateFilmeAtorValidation : AbstractValidator<UpdateFilmeAtorDto>
{
    public UpdateFilmeAtorValidation()
    {
        RuleFor(x => x.FilmeId)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.AtorId)
            .NotEmpty()
            .NotNull()
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x.Papel)
            .NotEmpty()
            .NotNull();
    }
}


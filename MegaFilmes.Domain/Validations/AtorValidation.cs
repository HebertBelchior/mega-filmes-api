using FluentValidation;
using MegaFilmes.Domain.Dtos.AtorDto;

namespace MegaFilmes.Domain.Validations;

public class CreateAtorValidation : AbstractValidator<CreateAtorDto>
{
    public CreateAtorValidation()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .NotNull();
    }
}

public class UpdateAtorValidation : AbstractValidator<UpdateAtorDto>
{
    public UpdateAtorValidation()
    {
        RuleFor(x => x.Nome)
            .NotEmpty()
            .NotNull();
    }
}

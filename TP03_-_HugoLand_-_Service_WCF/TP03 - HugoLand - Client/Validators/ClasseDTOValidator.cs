using FluentValidation;
using HugoWorld_Client.HL_Services;

namespace Hugoworld.Validators {

    public class ClasseDTOValidator : AbstractValidator<ClasseDTO> {

        public ClasseDTOValidator() {
            RuleFor(c => c.NomClasse)
                .NotEmpty()
                .WithMessage("Please provide a name")
                .MaximumLength(255)
                .WithMessage("Please provide a shorter name");

            RuleFor(c => c.Description)
                .NotEmpty()
                .WithMessage("Please provide a description")
                .MaximumLength(255)
                .WithMessage("Please provide a shorter ");

            RuleFor(c => c.StatBaseStr)
                .NotEmpty()
                .WithMessage("Please provide a base strength")
                .GreaterThan(0)
                .WithMessage("Please insert value higher than 0");

            RuleFor(c => c.StatBaseDex)
                .NotEmpty()
                .WithMessage("Please provide a base dexterity")
                .GreaterThan(0)
                .WithMessage("Please insert value higher than 0");

            RuleFor(c => c.StatBaseVitalite)
                .NotEmpty()
                .WithMessage("Please provide a base vitality")
                .GreaterThan(0)
                .WithMessage("Please insert value higher than 0");

            RuleFor(c => c.StatBaseInt)
                .NotEmpty()
                .WithMessage("Please provide a base integrity")
                .GreaterThan(0)
                .WithMessage("Please insert value higher than 0");

            RuleFor(c => c.MondeId)
                .NotEmpty()
                .WithMessage("Please provide a world");
        }
    }
}
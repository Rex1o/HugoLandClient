using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HugoWorld.WCF.DTOs;
using FluentValidation;

namespace HugoWorld.WCF.Validators
{
    public class ClasseDTOValidator : AbstractValidator<ClasseDTO>
    {
        public ClasseDTOValidator()
        {
            RuleFor(c => c.NomClasse)
                .NotEmpty()
                .WithMessage("Please provide a name")
                .MaximumLength(50)
                .WithMessage("Please provide a shorter name");
        }
    }
}

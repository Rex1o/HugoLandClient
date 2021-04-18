﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HugoWorld_Client.HL_Services;
using FluentValidation;

namespace Hugoworld.Validators
{
    public class ClasseDTOValidator : AbstractValidator<ClasseDTO>
    {
        public ClasseDTOValidator() {
            RuleFor(c => c.NomClasse)
                .NotEmpty()
                .WithMessage("Please provide a name")
                .MaximumLength(255)
                .WithMessage("Please provide a shorter name");

            RuleFor(c => c.Descrpition)
                .NotEmpty()
                .WithMessage("Please provide a description")
                .MaximumLength(255)
                .WithMessage("Please provide a shorter ");

            RuleFor(c => c.StatBaseStr)
                .NotEmpty()
                .WithMessage("Please provide a base strenght");


            RuleFor(c => c.StatBaseDex)
                .NotEmpty()
                .WithMessage("Please provide a base dexterity");

            RuleFor(c => c.StatBaseVitalite)
                .NotEmpty()
                .WithMessage("Please provide a base vitality");

                RuleFor(c => c.StatBaseInt)
                .NotEmpty()
                .WithMessage("Please provide a base integrity");

            RuleFor(c => c.MondeId)
                .NotEmpty()
                .WithMessage("Please provide a world");
        }
    }
}
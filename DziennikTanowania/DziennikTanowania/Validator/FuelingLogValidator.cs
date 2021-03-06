﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using DziennikTanowania.Models;

namespace DziennikTanowania.Validator
{
    public class FuelingLogValidator :AbstractValidator<FuelingLog>
    {
        public FuelingLogValidator()
        {
            RuleFor(c => c.ActualMileage).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(c => c.AmountOfRefueledFuel).NotNull().GreaterThan(0);
            RuleFor(c => c.PricePerLiter).NotNull().GreaterThan(0);
            RuleFor(c => c.DateTime).Must(d => ValidateStringEmpty(d.ToString())).WithMessage("Data nie może być pusta");
            RuleFor(c => c.RefuelingType).NotNull();
        }

        bool ValidateStringEmpty(string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }
        
    }
}

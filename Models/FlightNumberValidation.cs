﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace VuelosCRUD.Models
{
    public class FlightNumberValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {


            var vuelo = (Vuelo)validationContext.ObjectInstance;

            string[] parts = vuelo.NumeroDeVuelo.Split(' ');
            if (parts.Length != 2)
            {
                return new ValidationResult("Debe haber un espacio entre código de aerolínea y número.");
            }
            string airlineCodeLetters = parts[0]; //primera parte

            if (!Regex.IsMatch(airlineCodeLetters, @"^[a-zA-Z]+$"))
            {
                return new ValidationResult("La primera parte deben ser letras.");
            }

            string airlineCodeNumbers = parts[0]; //segunda parte

            if (int.TryParse(airlineCodeNumbers, out int num))
            {
                return new ValidationResult("La segunda parte deben ser numeros.");
            }

            return ValidationResult.Success;
        }
    }
}


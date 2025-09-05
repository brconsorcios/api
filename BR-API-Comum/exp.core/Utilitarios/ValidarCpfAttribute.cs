using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace exp.core.Utilitarios
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidarCpfAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var cpf = value.ToString();
                if (Regex.IsMatch(cpf, RegexHelpers.CpfPattern) && Funcao.IsCpf(cpf.RetirarAlfabeto()))
                    return ValidationResult.Success;

                return new ValidationResult(ErrorMessage);
            }

            return null;
        }
    }
}
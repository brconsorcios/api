using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace exp.core.Utilitarios
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter)]
    public class ValidarCpfCnpjAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var cpfcnpj = value.ToString();
                if (Regex.IsMatch(cpfcnpj, RegexHelpers.CpfCnpjPattern) && (Funcao.IsCpf(cpfcnpj.RetirarAlfabeto()) ||
                                                                            Funcao.IsCnpj(cpfcnpj.RetirarAlfabeto())))
                    return ValidationResult.Success;

                return new ValidationResult(ErrorMessage);
            }

            return null;
        }
    }
}
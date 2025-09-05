using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exp.dados.Uteis
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FileExtensionsAttribute : ValidationAttribute /*, IClientValidatable*/
    {
        public FileExtensionsAttribute(string fileExtensions)
        {
            ValidExtensions = fileExtensions.Split('|').ToList();
        }

        private List<string> ValidExtensions { get; }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file != null)
            {
                var fileName = file.FileName;
                var isValidExtension = ValidExtensions.Any(y => fileName.EndsWith(y));
                return isValidExtension;
            }

            return true;
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    var rule = new ModelClientFileExtensionValidationRule(ErrorMessage, ValidExtensions);
        //    yield return rule;
        //}
    }

    //public class ModelClientFileExtensionValidationRule : ModelClientValidationRule
    //{
    //    public ModelClientFileExtensionValidationRule(string errorMessage, List<string> fileExtensions)
    //    {
    //        ErrorMessage = errorMessage;
    //        ValidationType = "fileextensions";
    //        ValidationParameters.Add("fileextensions", string.Join(",", fileExtensions));
    //    }
    //}
}
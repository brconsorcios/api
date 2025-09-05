using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace exp.dados.Uteis
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class FileSizeAttribute : ValidationAttribute /*, IClientValidatable*/
    {
        public FileSizeAttribute(int fileSizeLimit)
        {
            FileSizeLimit = fileSizeLimit;
        }

        private int FileSizeLimit { get; }

        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;
            if (file != null)
            {
                var fileSize = file.ContentLength;
                var isValidFileSize = fileSize <= FileSizeLimit;
                return isValidFileSize;
            }

            return true;
        }

        //public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        //{
        //    var rule = new ModelClientFileSizeValidationRule(ErrorMessage, FileSizeLimit);
        //    yield return rule;
        //}
    }

    //public class ModelClientFileSizeValidationRule : ModelClientValidationRule
    //{
    //    public ModelClientFileSizeValidationRule(string errorMessage, int fileSizeLimit)
    //    {
    //        ErrorMessage = errorMessage;
    //        ValidationType = "filesize";
    //        ValidationParameters.Add("filesizelimit", fileSizeLimit);
    //    }
    //}
}
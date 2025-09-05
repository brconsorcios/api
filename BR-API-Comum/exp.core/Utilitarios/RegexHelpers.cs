namespace exp.core.Utilitarios
{
    public class RegexHelpers
    {
        public const string CpfPattern = @"^[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}$";

        public const string CnpjPattern = @"^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}-[0-9]{2}$";

        public const string CpfCnpjPattern =
            @"(^[0-9]{3}\.[0-9]{3}\.[0-9]{3}-[0-9]{2}$)|(^[0-9]{2}\.[0-9]{3}\.[0-9]{3}\/[0-9]{4}-[0-9]{2}$)";

        public const string TelephonePattern = @"^\([0-9]{2}\) [0-9]{4}-[0-9]{4}$";

        public const string CellphonePattern = @"^\([0-9]{2}\) [0-9]{4,5}-[0-9]{4}$";
    }
}
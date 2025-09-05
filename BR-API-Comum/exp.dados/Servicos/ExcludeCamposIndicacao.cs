namespace exp.dados
{
    public static class ExcludeCamposIndicacao
    {
        public static string BuscaCampos(int tipo_indicacao)
        {
            switch (tipo_indicacao)
            {
                case 0:
                    // "Cliente não finalizou";
                    return "Cliente não finalizou";
                case 1:
                    // "Quero Comprar pela Internet";
                    return "campo1,campo2";
                case 2:
                    // "Quero Receber uma visita";
                    return "campo1,campo2";
                case 3:
                    // "Quero Receber uma ligação";
                    return "campo1,campo2";
                case 4:
                    // "Quero Receber um E-mail";
                    return "campo1,campo2";
                case 5:
                    // "Fale Conosco";
                    return "campo1,campo2";
                case 6:
                    // "Ligamos para você";
                    return "campo1,campo2";
                case 7:
                    // "Email ou Telefone - Meu Patrimônio";
                    return "campo1,campo2";
                case 8:
                    // "Agenda - Meu Patrimônio";
                    return "campo1,campo2";
                case 9:
                    // "Fale Fácil";
                    return "campo1,campo2";
                default:
                    return string.Empty;
            }
        }
    }
}
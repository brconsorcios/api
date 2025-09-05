namespace exp.dados
{
    public class tbparceiros_end
    {
        public int id_tbparceiros { get; set; } //'0',
        public string endereco { get; set; } //'endereço s',
        public string numero { get; set; } //'número do endereço s',
        public string complemento { get; set; } //'complemento n',
        public string bairro { get; set; } //'bairro n',
        public string cidade { get; set; } //'nome da cidade s',
        public string uf { get; set; } //
        public string cep { get; set; } //
        public string tipo_endereco { get; set; } //

        #region Relacionamentos

        public tbparceiro tbparceiro { get; set; }

        #endregion
    }
}
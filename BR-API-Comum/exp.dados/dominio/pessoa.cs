using System;

namespace exp.dados
{
    public class pessoa
    {
        //Parâmetro		Tipo		Descrição		Obrigatoriedade
        public int id_usuario { get; set; } //	Integer	,	Identificador do Usuário (criar parâmetro)	,	S

        public int
            id_pessoa { get; set; } //	Integer	,	Identificador da Pessoa (retornado do Web Service Cliente Efetivo)	,	S

        public string
            cd_pessoa { get; set; } //	Varchar(20)	,	Código da Pessoa (retornado do Web Service Cliente Efetivo)	,	S

        public string nm_pessoa { get; set; } //	Varchar(80)	,	Nome da Pessoa	,	S
        public string no_documento { get; set; } //	Varchar(20)	,	Documento (RG)	,	S
        public string sh { get; set; }
        public DateTime? dt_expedicao { get; set; } //	DateTime	,	Data de Expedição	,	S
        public string nm_orgao_emissor { get; set; } //	Varchar(30)	,	Órgão Emissor do documento	,	S
        public string st_tipo_pessoa { get; set; } //	Char(1)	,	Tipo de Pessoa (F – Física, J – Jurídica)	,	S
        public string cd_inscricao_nacional { get; set; } //	Varchar(14)	,	CIC / CPF	,	S
        public DateTime? dt_nascimento { get; set; } //	DateTime	,	Data de Nascimento	,	S
        public string sn_politicamente_exposto { get; set; } //	Char(1)	,	Passar S ou N.	,	S
        public decimal vl_renda { get; set; } //	Numeric(18,2)	,	Valor da Renda	,	N
        public int id_profissao { get; set; } //	Integer	,	Identificador da Profissão	,	N
        public string endereco { get; set; } //	Varchar(80)	,	Endereço	,	S
        public string no_endereco { get; set; } //	Varchar(10)	,	Número do Endereço	,	S
        public string complemento { get; set; } //	Varchar(20)	,	Complemento	,	N
        public string bairro { get; set; } //	Varchar(30)	,	Bairro	,	N
        public string nm_cidade { get; set; } //	Varchar(40)	,	Nome da Cidade	,	S
        public string id_uf { get; set; }
        public string cep { get; set; } //	Char(8)	,	CEP	,	S
        public string ddd { get; set; } //	Char(4)	,	DDD	,	S
        public string telefone { get; set; } //	Varchar(30)	,	Telefone	,	S
        public string e_mail { get; set; } //	Varchar(50)	,	E-mail	,	S
        public string ddd_comercial { get; set; } //	Char(4)	,	DDD comercial	,	N
        public string telefone_comercial { get; set; } //	Varchar(30)	,	Telefone Comercial	,	N

        public string
            st_estado_civil
        {
            get;
            set;
        } //	Char(1)	,	C – Casado, D – Desquitado, J – Separado Judicialmente, O – Outro, R - Divorciado, S – Solteiro, B – Concubinato, U – União Estável, V - Viúvo	,	S

        public string endereco_comercial { get; set; } //	Varchar(80)	,	Endereço Comercial	,	N
        public string no_endereco_comercial { get; set; } //	Varchar(10)	,	Número do Endereço Comercial	,	N
        public string complemento_comercial { get; set; } //	Varchar(20)	,	Complemento Comercial	,	N
        public string bairro_comercial { get; set; } //	Varchar(30)	,	Bairro Comercial	,	N
        public string nm_cidade_comercial { get; set; } //	Varchar(40)	,	Nome da Cidade Comercial	,	N
        public string id_uf_comercial { get; set; }
        public string cep_comercial { get; set; } //	Char(8)	,	CEP Comercial	,	N
        public string st_sexo { get; set; } //	Char(1)	,	Sexo (M – Masculino, F – Feminino)	,	S
        public string nm_fantasia { get; set; } //	Varchar(80)	,	Nome Fantasia (Pessoa Jurídica)	,	N
        public string cargo { get; set; } //	Varchar(80)	,	Cargo (Pessoa Jurídica)	,	N
        public string observacao { get; set; } //	Varchar(255)	,	Observação	,	N

        public string
            nm_socio
        {
            get;
            set;
        } //	Varchar(80)	,	Nome do Sócio Majoritário (Pessoa Jurídica)	,	S (somente em caso de pessoa jurídica)

        public string
            cd_inscricao_nacional_socio
        {
            get;
            set;
        } //	Varchar(14)	,	CIC / CPF do Sócio Majoritário (Pessoa Jurídica)	,	S (somente em caso de pessoa jurídica)

        public string
            st_sexo_socio
        {
            get;
            set;
        } //	Char(1)	,	Sexo do Sócio Majoritário (Pessoa Jurídica)	,	S (somente em caso de pessoa jurídica)

        public string
            st_estado_civil_socio { get; set; } //	Char(1)	,	Estado Civil do Sócio Majoritário (Pessoa Jurídica)	,	N

        public DateTime?
            dt_nascimento_socio
        {
            get;
            set;
        } //	DateTime	,	Data de Nascimento do Sócio Majoritário (Pessoa Jurídica)	,	S (somente em caso de pessoa jurídica)

        public int id_cidade { get; set; } //	Integer	,	Identificador da Cidade	,	S
        public int id_cidade_comercial { get; set; } //	Integer	,	Identificador da Cidade Comercial	,	N

        /*
        //#### Manutenção pessoa fisica e juridica ##################################
        public int ID_Pessoa  { get; set; }//Integer	Identificador da pessoa	S
        public string SN_Politicamente_Exposto { get; set; }//	String	S/N	S
        public string CD_Inscricao_Nacional { get; set; }
                //	String	Passar o CPF já cadastrado caso seja manutenção.	S
                //  Passar o CNPJ já cadastrado caso seja manutenção.
        public string NO_Documento { get; set; }
                //	String RG ou Titulo de eleitos	Outro Documento da Pessoa	S
                //	String Inscrição estatual	Outro Documento	S
        public int ID_Tipo_Documento { get; set; }
                //	Integer	Identificador do tipo de doc.	S
                //	Integer	Identificador do tipo de documento	S

        //#### ------------------------ ##################################

        //#### Manutenção pessoa fisica ##################################
                public int ID_Pessoa_Conjuge { get; set; }//	Integer	Identificador do cônjuge,  obrigatório caso a pessoa sendo realizada a manutenção seja casada, caso contrário passar zero.	S
        public string NM_Pessoa { get; set; }//	String	Nome completo da pessoa / Caso a pessoa já esteja cadastrada, passar o nome retornado de pessoa física.	S
        public  Nullable<DateTime>  DT_Expedicao { get; set; }//	DateTime	Data de expedição do documento	S
        public string NM_Orgao_Emissor { get; set; }//	String	Ex: “SSP/SP”	S
        public  Nullable<DateTime>  DT_Nascimento { get; set; }//	DateTime	Data de nascimento	S
        public string ST_Sexo { get; set; }//	String	F ou M 	S
                public int ID_Estado_Civil { get; set; }//	Integer	Identificador do estado civil	S
                public string NM_Nacionalidade { get; set; }//	String	--	S

        public int ID_Profissao { get; set; }//	Integer	Identificador da Profissão da pessoa	S
        public string VL_Renda { get; set; }//	Double	Valor da Renda	S

                public string Naturalidade { get; set; }//	String	--	S
                public string ID_Regime_Casamento { get; set; }//	Integer	Passar zero, caso pelo estado civil não seja necessário esta informação.	S
                public Nullable<DateTime> DT_Casamento { get; set; }//	DateTime	Passar 01/01/1900, caso pelo estado civil não seja necessário esta informação.	S
        //#### ------------------------ ##################################

        //#### Manutenção pessoa juridica ##################################
            public string NM_Razao_Social { get; set; }//	String	Razão social da empresa	S
            public string DT_Fundacao { get; set; }//	DateTime	--	S
        public string NM_Fantasia { get; set; }//	String	Nome Fantasia	S
            public string VL_Capital_Social	{ get; set; }//Double	Valor do capital social	S
        public string Observação { get; set; }//	String	--	S
            public string VL_Faturamento_Medio { get; set; }//	Double	Faturamento Médio	S

        public string ID_Pessoa_Socio { get; set; }//	Integer	Identificador da pessoa sócio se houver	S
        public string Cargo_Socio { get; set; }//	String	--	S
        public string PE_Participacap_Socio { get; set; }//	Double	--	S
        //#### ------------------------ ##################################
        */
        // O tipo de telefone pessoa jurica deve se comercial


        //CREATE TABLE `pessoas` (
        //  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
        //  `id_pessoa` int(11) DEFAULT NULL COMMENT 'identificador da pessoa (retornado do web service cliente efetivo) s',
        //  `cd_pessoa` varchar(20) DEFAULT NULL COMMENT 'código da pessoa (retornado do web service cliente efetivo) s',
        //  `nm_pessoa` varchar(80) NOT NULL COMMENT 'nome da pessoa s',
        //  `sh` varchar(50) DEFAULT NULL,
        //  `no_documento` varchar(20) NOT NULL COMMENT 'documento (rg) s',
        //  `dt_expedicao` datetime NOT NULL COMMENT 'data de expedição s',
        //  `nm_orgao_emissor` varchar(30) NOT NULL COMMENT 'órgão emissor do documento s',
        //  `st_tipo_pessoa` char(1) NOT NULL COMMENT 'tipo de pessoa (f – física, j – jurídica) s',
        //  `cd_inscricao_nacional` varchar(14) NOT NULL COMMENT 'cic / cpf s',
        //  `dt_nascimento` datetime NOT NULL COMMENT 'data de nascimento s',
        //  `sn_politicamente_exposto` char(1) NOT NULL COMMENT 'passar s ou n. s',
        //  `vl_renda` decimal(18,2) NOT NULL COMMENT 'valor da renda n',
        //  `id_profissao` int(11) NOT NULL COMMENT 'identificador da profissão n',
        ////-------------------
        //  `endereco` varchar(80) NOT NULL COMMENT 'endereço s',
        //  `no_endereco` varchar(10) NOT NULL COMMENT 'número do endereço s',
        //  `complemento` varchar(20) DEFAULT NULL COMMENT 'complemento n',
        //  `bairro` varchar(30) DEFAULT NULL COMMENT 'bairro n',
        //  `nm_cidade` varchar(40) NOT NULL COMMENT 'nome da cidade s',
        //  `id_uf` varchar(12) DEFAULT NULL,
        //  `cep` char(8) NOT NULL COMMENT 'cep s',


        //  `ddd` char(4) NOT NULL COMMENT 'ddd s',
        //  `telefone` varchar(30) NOT NULL COMMENT 'telefone s',

        //  `e_mail` varchar(50) NOT NULL COMMENT 'e-mail s',

        //  `ddd_comercial` char(4) DEFAULT NULL COMMENT 'ddd comercial n',
        //  `telefone_comercial` varchar(30) DEFAULT NULL COMMENT 'telefone comercial n',

        //  `st_estado_civil` char(1) NOT NULL COMMENT 'c – casado, d – desquitado, j – separado judicialmente, o – outro, r - divorciado, s – solteiro, b – concubinato, u – união estável, v - viúvo s',

        //   `endereco_comercial` varchar(80) DEFAULT NULL COMMENT 'endereço comercial n',
        //  `no_endereco_comercial` varchar(10) DEFAULT NULL COMMENT 'número do endereço comercial n',
        //  `complemento_comercial` varchar(20) DEFAULT NULL COMMENT 'complemento comercial n',
        //  `bairro_comercial` varchar(30) DEFAULT NULL COMMENT 'bairro comercial n',
        //  `id_uf_comercial` varchar(12) DEFAULT NULL,
        //  `nm_cidade_comercial` varchar(40) DEFAULT NULL COMMENT 'nome da cidade comercial n',
        //  `cep_comercial` char(8) DEFAULT NULL COMMENT 'cep comercial n',

        //  `st_sexo` char(1) NOT NULL COMMENT 'sexo (m – masculino, f – feminino) s',

        //  `nm_fantasia` varchar(80) DEFAULT NULL COMMENT 'nome fantasia (pessoa jurídica) n',
        //  `cargo` varchar(80) DEFAULT NULL COMMENT 'cargo (pessoa jurídica) n',
        //  `observacao` varchar(255) DEFAULT NULL COMMENT 'observação n',
        //  `nm_socio` varchar(80) DEFAULT NULL COMMENT 'nome do sócio majoritário (pessoa jurídica) s (somente em caso de pessoa jurídica)',

        //  `cd_inscricao_nacional_socio` varchar(14) DEFAULT NULL COMMENT 'cic / cpf do sócio majoritário (pessoa jurídica) s (somente em caso de pessoa jurídica)',
        //  `st_sexo_socio` char(1) DEFAULT NULL COMMENT 'sexo do sócio majoritário (pessoa jurídica) s (somente em caso de pessoa jurídica)',
        //  `st_estado_civil_socio` char(1) DEFAULT NULL COMMENT 'estado civil do sócio majoritário (pessoa jurídica) n',
        //  `dt_nascimento_socio` datetime DEFAULT NULL COMMENT 'data de nascimento do sócio majoritário (pessoa jurídica) s (somente em caso de pessoa jurídica)',
        //  `id_cidade` int(11) NOT NULL COMMENT 'identificador da cidade s',
        //  `id_cidade_comercial` int(11) DEFAULT NULL COMMENT 'identificador da cidade comercial n',
        //  PRIMARY KEY (`id_usuario`)
        //) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
    }
}
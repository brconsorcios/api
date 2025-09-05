using BrConsorcio.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrConsorcio.Api.Helpers
{
    public class CadastroClienteValidar
    {
        //public ModelStateDictionary msd { get; set; }
        //public CadastroClienteModel form { get; set; }
        public string msg { get; set; }
        public string cadastrado { get; set; }

        public Dictionary<string, string> erros { get; set; }

        public CadastroClienteValidar(CadastroClienteModel formulario)
        {
            erros = new Dictionary<string, string>();
         

            #region Pessoa Fisica
            if (formulario.st_tipo_pessoa == "F")
            {
            }
            #endregion

            #region Socio Pessoa Juridica

            if (formulario.id_pessoa == 0)
            {


                if (formulario.st_tipo_pessoa == "J")
                {
                    if (string.IsNullOrEmpty(formulario.socio_nome))
                    {
                        erros.Add("socio_nome", "Senha is required");
                        //erro.Add("socio_nome", new ValueProviderResult(formulario.socio_nome, formulario.socio_nome, null));
                    }


                    if (string.IsNullOrEmpty(formulario.socio_cpf))
                    {
                        erros.Add("socio_cpf", "o CPF do sócio é obrigatório");
                     //   ModelState.SetModelValue("socio_cpf", new ValueProviderResult(formulario.socio_cpf, formulario.socio_cpf, null));

                    }
                    else
                    {
                        if (!Funcao.IsCpf(formulario.socio_cpf))
                        {
                            erros.Add("socio_cpf", "o CPF do sócio não é válido");
                          //  ModelState.SetModelValue("socio_cpf", new ValueProviderResult(formulario.socio_cpf, formulario.socio_cpf, null));
                        }

                    }

                    if (string.IsNullOrEmpty(formulario.socio_sexo))
                    {

                        erros.Add("socio_sexo", "Informe o Sexo do sócio");

                        //You missed off SetModelValue?
                      //  ModelState.SetModelValue("socio_sexo", new ValueProviderResult(formulario.socio_sexo, formulario.socio_sexo, null));

                    }

                    if (string.IsNullOrEmpty(formulario.socio_nasc.ToString()))
                    {

                        erros.Add("socio_nasc", "Informe o Sexo do sócio");

                        //You missed off SetModelValue?
                      //  ModelState.SetModelValue("socio_nasc", new ValueProviderResult(formulario.socio_nasc.ToString(), formulario.socio_nasc.ToString(), null));

                    }
                }
            }
            #endregion

            this.cadastrado = "nao";

            //#region Tratar cliente cadastrado
            //if (erros.ContainsKey("cd_inscricao_nacional"))
            //{
            //    //if (ModelState["cd_inscricao_nacional"].Errors.Count() > 0)
            //    //{
            //    //    jacadastrado = "sim";
            //    //}

            //    if (erros["cd_inscricao_nacional"].Count() > 0)
            //    {
            //        //O Cliente já está cadastrado
            //        var er = erros["cd_inscricao_nacional"];
            //        if (er.Any())
            //        {
            //            foreach (var error in er)
            //            {
            //                if (error.ErrorMessage.StartsWith("O Cliente j"))
            //                {
            //                    er.Remove(error);
            //                    this.cadastrado = "sim";
            //                    break;
            //                }
            //            }
            //        }
            //    }

            //    //remove quando cliente já está cadastrado
            //    //if (ModelState.FirstOrDefault(x => x.Key.Equals("cd_inscricao_nacional")).Value != null)
            //    //{
            //    //    ModelState["cd_inscricao_nacional"].Errors.Clear();
            //    //}
            //    if (ModelState.FirstOrDefault(x => x.Key.Equals("nome")).Value != null)
            //    {
            //        ModelState["nome"].Errors.Clear();
            //    }
            //    if (formulario.st_tipo_pessoa == "J")
            //    {
            //        //Se for pessoa jurídica não verificar id_profissao
            //        var prof = ModelState.FirstOrDefault(x => x.Key.Equals("profissao"));
            //        if (prof.Value != null)
            //        {
            //            ModelState["profissao"].Errors.Clear();
            //        }

            //        string messages = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage));

            //        var profpf = ModelState.FirstOrDefault(x => x.Key.Equals("cliente_pf.id_profissao"));
            //        if (profpf.Value != null)
            //        {
            //            ModelState["cliente_pf.id_profissao"].Errors.Clear();
            //        }

            //    }

            //}
         //   #endregion
          

        }

        public ClienteModel CadastroClienteNovoPreparar(CadastroClienteModel formulario)
        {
            ClienteModel cliente = new ClienteModel();
            cliente.id = formulario.id;

            string comentario = string.Empty;

            int id_cidade = 1;//LONDRINA
            if (Funcao.IsNumeric(formulario.cliente_end.id_cidade.ToString()))
            {
                id_cidade = Convert.ToInt32(formulario.cliente_end.id_cidade);
            }
            int id_pessoa = 0;
            if (Funcao.IsNumeric(formulario.id_pessoa.ToString()))
            {
                id_pessoa = Convert.ToInt32(formulario.id_pessoa);
            }
            cliente.id_pessoa = id_pessoa;
            cliente.st_tipo_pessoa = formulario.st_tipo_pessoa;
            cliente.cd_pessoa = "0";
            cliente.sn_politicamente_exposto = "N";//"o "S" é utilizado para pessoa famosas ou políticos e etc."
            cliente.cd_inscricao_nacional = formulario.cd_inscricao_nacional;
            cliente.no_documento = formulario.no_documento;
            if (cliente.st_tipo_pessoa == "F")
            {
                cliente.id_tipo_documento = 2; // 2 = RG 4 Inscrição estadual
            }
            else
            {
                cliente.id_tipo_documento = 4; // 2 = RG 4 Inscrição estadual
            }
            cliente.sh = DateTime.Now.AddSeconds(1).ToString("MMddyyHHmmss"); //gerar senha nova

            if (!Funcao.IsNumeric(formulario.sh))
            {
                cliente.sh = formulario.sh;
            }

            cliente.nome = formulario.nome;
            cliente.dt_nascfund = Convert.ToDateTime(formulario.dt_nascfund);

            //if (cliente.st_tipo_pessoa == "F")
            //{
            //    //cliente.vl_rendacapital = Convert.ToDecimal("10000,10");
            //    comentario += " Este cliente foi cadastrado pelo sistema com a renda de R$  " + cliente.vl_rendacapital.ToString() + ". ";
            //}
            //else
            //{
            //    //cliente.vl_rendacapital = Convert.ToDecimal("20000,10");
            //    comentario += " Esta empresa foi cadastrada pelo sistema com o capital de R$  " + cliente.vl_rendacapital.ToString() + ". ";
            //}

            if ((formulario.id_pessoa == 0) || (formulario.id_pessoa != 0 && !string.IsNullOrEmpty(formulario.aut_renda)))
            {
                cliente.vl_rendacapital = formulario.vl_rendacapital;
            }

            if (cliente.st_tipo_pessoa == "F")
            {
                cliente.cliente_pf = new cliente_pf();
                //cliente.cliente_pf.id_pessoa = 23;


                if (!Funcao.IsDateTime(formulario.cliente_pf.nm_orgao_emissor))
                {
                    cliente.cliente_pf.dt_expedicao = Convert.ToDateTime(formulario.cliente_pf.dt_expedicao);
                }
                else
                {
                    cliente.cliente_pf.dt_expedicao = Convert.ToDateTime("1900-01-01");
                    comentario += " A DATA DE EXPEDIÇÃO não foi informada. ";
                }

                cliente.cliente_pf.dt_expedicao = Convert.ToDateTime(formulario.cliente_pf.dt_expedicao);

                if (!string.IsNullOrEmpty(formulario.cliente_pf.nm_orgao_emissor))
                {
                    cliente.cliente_pf.nm_orgao_emissor = formulario.cliente_pf.nm_orgao_emissor;
                }
                else
                {
                    cliente.cliente_pf.nm_orgao_emissor = "SSP";
                    comentario += " O ÓRGÃO EMISSOR DO RG não foi informado. ";
                }


                cliente.cliente_pf.st_sexo = formulario.cliente_pf.st_sexo;
                cliente.cliente_pf.id_estado_civil = Convert.ToInt32(formulario.cliente_pf.id_estado_civil);

                if (!string.IsNullOrEmpty(formulario.cliente_pf.nm_nacionalidade))
                {
                    cliente.cliente_pf.nm_nacionalidade = formulario.cliente_pf.nm_nacionalidade;
                }
                else
                {
                    cliente.cliente_pf.nm_nacionalidade = "brasileiro";
                    comentario += " A NACIONALIDADE padrão é brasileiro. ";
                }
                if (!string.IsNullOrEmpty(formulario.cliente_pf.naturalidade))
                {
                    cliente.cliente_pf.naturalidade = formulario.cliente_pf.naturalidade;
                }
                else
                {
                    if (!string.IsNullOrEmpty(formulario.cidade))
                    {
                        cliente.cliente_pf.naturalidade = formulario.cidade;
                        comentario += " Na NATURALIDADE foi informado a cidade " + formulario.cidade.ToUpper() + " do endereço. ";
                    }
                }

                cliente.cliente_pf.id_profissao = Convert.ToInt32(formulario.cliente_pf.id_profissao);// 4017; // EMPRESARIO
                cliente.cliente_pf.id_regime_casamento = 0;
                cliente.cliente_pf.id_pessoa_conjuge = 0;
                cliente.cliente_pf.profissao = formulario.profissao;
                //cliente.cliente_pf.profissao = formulario.cliente_pf.profissao;
                cliente.cliente_pf.dt_casamento = Convert.ToDateTime("1900-01-01");// "1900-01-01";
                cliente.cliente_pj = null;

            }
            else
            {
                cliente.cliente_pf = null;
                cliente.cliente_pj = new cliente_pj();
                cliente.cliente_pj.vl_faturamento_medio = Convert.ToDecimal("200000,10");
                comentario += " Esta empresa foi cadastrada pelo sistema com o FATURAMENTO MÉDIO de R$  " + cliente.cliente_pj.vl_faturamento_medio.ToString() + ". ";

                //como fazer isso
                cliente.cliente_pj.id_pessoa_socio = 0;
                cliente.cliente_pj.cargo_socio = "";
                cliente.cliente_pj.pe_participacao_socio = Convert.ToDecimal("0"); ;
                cliente.cliente_pj.observacao = "SOCIO: " + formulario.socio_nome + " - CPF: " + formulario.socio_cpf + " - Sexo: " + formulario.socio_sexo + " - DATA NASC.: " + formulario.socio_nasc + " - Estado Civil: " + formulario.socio_estado_civil + " - Celular: " + formulario.celular + " ";
                cliente.dt_nascfund = formulario.dt_nascfund;
                cliente.cliente_pj.nm_socio = formulario.socio_nome;
                cliente.cliente_pj.cpf_socio = formulario.socio_cpf;
                cliente.cliente_pj.sexo_socio = formulario.socio_sexo;
                cliente.cliente_pj.dt_nasc_socio = Convert.ToDateTime(formulario.socio_nasc);
                cliente.cliente_pj.estado_civil_socio = cliente.cliente_pj.estado_civil_socio;
                cliente.cliente_pj.id_estado_civil = Convert.ToInt32(formulario.socio_estado_civil);
                cliente.cliente_pj.celular_socio = formulario.celular;

                //comentario += "As informações do SOCIO estão no campo observação: " + cliente.cliente_pj.observacao + ". ";
            }

            //ENDEREÇO ##############################################################################
            cliente.cliente_end = new cliente_end();
            //cliente.cliente_end.id_pessoa = 23;
            cliente.cliente_end.endereco = formulario.cliente_end.endereco;
            cliente.cliente_end.no_endereco = formulario.cliente_end.no_endereco;
            cliente.cliente_end.complemento = formulario.cliente_end.complemento;
            cliente.cliente_end.bairro = formulario.cliente_end.bairro;
            cliente.cliente_end.nm_cidade = formulario.cidade;
            cliente.cliente_end.id_uf = formulario.cliente_end.id_uf;
            cliente.cliente_end.cep = formulario.cliente_end.cep.RetirarAlfabeto();

            int id_endereco = 0;
            if (Funcao.IsNumeric(formulario.cliente_end.id_endereco.ToString()))
            {
                id_endereco = Convert.ToInt32(formulario.cliente_end.id_endereco);
            }
            cliente.cliente_end.id_endereco = id_endereco;
            cliente.cliente_end.id_cidade = id_cidade;
            if (cliente.st_tipo_pessoa == "F")
            {
                cliente.cliente_end.id_tipo_endereco = 1; //RESIDENCIAL
                cliente.cliente_end.nm_tipo_endereco = "RESIDENCIAL";
            }
            else
            {
                cliente.cliente_end.id_tipo_endereco = 2; //COMERCIAL
                cliente.cliente_end.nm_tipo_endereco = "COMERCIAL";
            }
            cliente.cliente_end.caixa_postal = "";
            cliente.cliente_end.ds_referencia_endereco = "";
            cliente.cliente_end.no_sequencia = 0;

            //TELEFONES ##############################################################################
            cliente.cliente_fone = new cliente_fone();
            int id_telefone = 0;
            if (Funcao.IsNumeric(formulario.cliente_fone.id_telefone.ToString()))
            {
                id_telefone = Convert.ToInt32(formulario.cliente_fone.id_telefone);
            }
            cliente.cliente_fone.id_telefone = id_telefone;
            cliente.cliente_fone.id_cidade = id_cidade;

            if (!string.IsNullOrEmpty(formulario.cliente_fone.id_uf))
            {
                cliente.cliente_fone.id_uf = formulario.cliente_fone.id_uf;
            }
            else
            {
                cliente.cliente_fone.id_uf = formulario.cliente_end.id_uf;
                if (!string.IsNullOrEmpty(formulario.cliente_end.id_uf))
                {
                    comentario += "O ID_UF do telefone não foi identificado e o sistema informou o " + formulario.cliente_end.id_uf.ToUpper() + " do endereço. ";
                }
            }

            if (cliente.st_tipo_pessoa == "F")
            {
                cliente.cliente_fone.id_tipo_telefone = 1; //RESIDENCIAL
            }
            else
            {
                cliente.cliente_fone.id_tipo_telefone = 2; //COMERCIAL
                // cliente.cliente_fone.id_tipo_telefone = 3; //CELULAR
            }

            if (!string.IsNullOrEmpty(formulario.cliente_fone.telefone))
            {
                string ddd = string.Empty;
                string telefone = string.Empty;
                string telstr = formulario.cliente_fone.telefone;

                int ntel = telstr.IndexOf(')') + 1;
                if (ntel > 0)
                {
                    telefone = telstr.Substring(ntel);
                    telefone = telefone.Trim().RetirarAlfabeto();
                    ddd = telstr.Substring(0, ntel);
                    ddd = ddd.Trim().RetirarAlfabeto();
                }
                else
                {
                    telefone = formulario.cliente_fone.telefone;
                }

                cliente.cliente_fone.ddd = ddd;
                cliente.cliente_fone.telefone = telefone;
            }


            cliente.cliente_fone.no_sequencia = 0;
            //CELULAR ##############################################################################

            if (!string.IsNullOrEmpty(formulario.cliente_fone.celular))
            {
                //sempre será cadastrado nunca modificado por isso zero
                cliente.cliente_fone.id_celular = 0;
                cliente.cliente_fone.id_cidade_celular = id_cidade;

                if (!string.IsNullOrEmpty(formulario.cliente_fone.id_uf))
                {
                    cliente.cliente_fone.id_uf_celular = formulario.cliente_fone.id_uf;
                }
                else
                {
                    cliente.cliente_fone.id_uf = formulario.cliente_end.id_uf;
                    comentario += "O ID_UF do telefone celular não foi identificado e o sistema informou o " + formulario.cliente_end.id_uf.ToUpper() + " do endereço. ";
                }
                cliente.cliente_fone.id_tipo_telefone = 3; //CELULAR


                if (formulario.cliente_fone.celular.Length > 0)
                {
                    string dddcel = string.Empty;
                    string celular = string.Empty;
                    string celstr = formulario.cliente_fone.celular;
                    int ncel = celstr.IndexOf(')') + 1;
                    if (ncel > 0)
                    {
                        celular = celstr.Substring(ncel);

                        celular = celular.Trim().RetirarAlfabeto();
                        dddcel = celstr.Substring(0, ncel);
                        dddcel = dddcel.Trim().RetirarAlfabeto();
                    }
                    else
                    {
                        celular = formulario.cliente_fone.celular;
                    }
                    cliente.cliente_fone.ddd_celular = dddcel;
                    cliente.cliente_fone.celular = celular;
                }
            }


            //EMAIL ##############################################################################
            cliente.cliente_email = new cliente_email();
            int id_email = 0;
            if (Funcao.IsNumeric(formulario.cliente_email.id_email.ToString()))
            {
                id_email = Convert.ToInt32(formulario.cliente_email.id_email);
            }
            cliente.cliente_email.id_email = id_email;
            cliente.cliente_email.e_mail = formulario.cliente_email.e_mail;

            this.msg = comentario;
            return cliente;
        }
    }
}

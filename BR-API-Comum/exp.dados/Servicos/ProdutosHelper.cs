using System.Collections.Generic;
using System.Linq;

namespace exp.dados.Servicos
{
    public static class ProdutosHelper
    {
        public enum ProdutoCategoria
        {
            Automoveis = 1,
            Motos = 2,
            Imoveis = 4,
            Caminhoes = 8,
            Servicos = 7,
            MaquinasEquipamentos = 11
        }

        private static readonly Dictionary<ProdutoCategoria, int[]> dic = new Dictionary<ProdutoCategoria, int[]>
        {
            { ProdutoCategoria.Automoveis, new[] { 1, 301 } },
            { ProdutoCategoria.Motos, new[] { 2 } },
            { ProdutoCategoria.Imoveis, new[] { 4, 302 } },
            { ProdutoCategoria.Caminhoes, new[] { 8 } },
            { ProdutoCategoria.Servicos, new[] { 7 } },
            { ProdutoCategoria.MaquinasEquipamentos, new[] { 11 } }
        };

        private static readonly List<ProdutoCategoriaDetails> listaPodutoCategoriaDetails =
            new List<ProdutoCategoriaDetails>
            {
                new ProdutoCategoriaDetails
                {
                    ProdutoCategoria = ProdutoCategoria.Automoveis, Titulo = "Carros", Url = "consorcio-de-carros",
                    ImagemHome = "consorcio-de-carro.jpg", ImagemLista = "consorcio-de-carro"
                },
                new ProdutoCategoriaDetails
                {
                    ProdutoCategoria = ProdutoCategoria.Motos, Titulo = "Motos", Url = "consorcio-de-motos",
                    ImagemHome = "consorcio-de-moto.jpg", ImagemLista = "consorcio-de-moto"
                },
                new ProdutoCategoriaDetails
                {
                    ProdutoCategoria = ProdutoCategoria.Imoveis, Titulo = "Imóveis", Url = "consorcio-de-imoveis",
                    ImagemHome = "consorcio-de-imoveis.jpg", ImagemLista = "consorcio-de-imovel"
                },
                new ProdutoCategoriaDetails
                {
                    ProdutoCategoria = ProdutoCategoria.Servicos, Titulo = "Serviços", Url = "consorcio-de-servicos",
                    ImagemHome = "consorcio-de-servicos.jpg", ImagemLista = "consorcio-de-servico"
                },
                new ProdutoCategoriaDetails
                {
                    ProdutoCategoria = ProdutoCategoria.Caminhoes, Titulo = "Caminhões", Url = "consorcio-de-caminhoes",
                    ImagemHome = "consorcio-de-caminhoes.jpg", ImagemLista = "consorcio-de-caminhao"
                },
                new ProdutoCategoriaDetails
                {
                    ProdutoCategoria = ProdutoCategoria.MaquinasEquipamentos, Titulo = "Maquinas e Equipamentos",
                    Url = "consorcio-de-maquinas-e-equipamentos", ImagemHome = "consorcio-maquinas-e-equipamentos.jpg",
                    ImagemLista = "consorcio-de-maquina-e-equipamento"
                }
            };

        public static ProdutoCategoria? CategoriaFromProdutoId(int produto_id)
        {
            return dic.Where(x => x.Value.Contains(produto_id)).FirstOrDefault().Key;
        }

        public static int[] GetProdutoIdsFromCategoria(ProdutoCategoria categoria)
        {
            try
            {
                return dic[categoria];
            }
            catch
            {
                return new int[0];
            }
        }

        public static ProdutoCategoriaDetails GetCategoriaDetails(ProdutoCategoria? categoria)
        {
            return listaPodutoCategoriaDetails.FirstOrDefault(x => x.ProdutoCategoria == categoria);
        }

        public static ProdutoCategoriaDetails GetCategoriaDetails(int produto_id)
        {
            var categoria = CategoriaFromProdutoId(produto_id);
            return GetCategoriaDetails(categoria);
        }

        public class ProdutoCategoriaDetails
        {
            public ProdutoCategoria ProdutoCategoria { get; set; }

            public string Titulo { get; set; }

            public string Url { get; set; }

            public string ImagemHome { get; set; }

            public string ImagemLista { get; set; }
        }
    }
}
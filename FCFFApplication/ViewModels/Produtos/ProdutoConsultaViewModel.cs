using FCFFApplication.ViewModels.Estoques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.ViewModels.Produtos
{
    public class ProdutoConsultaViewModel
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }

        public EstoqueConsultaViewModel Estoque { get; set; }

    }
}

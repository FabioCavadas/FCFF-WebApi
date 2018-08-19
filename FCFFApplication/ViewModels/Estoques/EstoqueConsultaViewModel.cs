using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.ViewModels.Estoques
{
    /// <summary>
    /// Classe que define o modelo de entrada e saida de dados para os serviços contidos na Aplicação.
    /// </summary>
    public class EstoqueConsultaViewModel
    {
        public int IdEstoque { get; set; }
        public string Nome { get; set; }
        public int QuantidadeDeProdutos { get; set; }

    }
}

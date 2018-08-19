using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.ViewModels.Produtos
{
    /// <summary>
    /// Classe que define o modelo de entrada e saida de dados para os serviços contidos na Aplicação.
    /// </summary>
    public class ProdutoEdicaoViewModel
    {
        [Required(ErrorMessage = "Informe o Id do Produto.")]
        public int IdProduto { get; set; }

        [MinLength(3, ErrorMessage = "Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage = "Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage = "Informe o Nome do Produto.")]
        public string Nome { get; set; }

        [Range(0.01, 9999, ErrorMessage = "Informe um valor entre {1} e {2}")]
        [Required(ErrorMessage = "Informe o Preço do Produto.")]
        public decimal Preco { get; set; }

        [Range(0.01, 999, ErrorMessage = "Informe um valor entre {1} e {2}")]
        [Required(ErrorMessage = "Informe a Quantidade do Produto.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "Informe o Estoque do Produto.")]
        public int IdEstoque { get; set; }

    }
}

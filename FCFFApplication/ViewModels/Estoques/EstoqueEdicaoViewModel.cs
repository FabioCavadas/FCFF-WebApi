using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.ViewModels.Estoques
{
    /// <summary>
    /// Classe que define o modelo de entrada e saida de dados para os serviços contidos na Aplicação.
    /// </summary>
    public class EstoqueEdicaoViewModel
    {
        [Required(ErrorMessage ="Informe o Id do Estoque.")]
        public int IdEstoque { get; set; }

        [MinLength(3, ErrorMessage ="Informe no mínimo {1} caracteres.")]
        [MaxLength(50, ErrorMessage ="Informe no máximo {1} caracteres.")]
        [Required(ErrorMessage ="Informe o Nome.")]
        public string Nome { get; set; }
    }
}

using FCFFApplication.ViewModels.Produtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.Contracts
{
    public interface IProdutoAppService
    {
        void Cadastrar(ProdutoCadastroViewModel model);

        void Atualizar(ProdutoEdicaoViewModel model);

        void Excluir(int idProduto);

        List<ProdutoConsultaViewModel> ConsultarTodos();

        ProdutoConsultaViewModel ConsultarPorId(int idProduto);

    }
}

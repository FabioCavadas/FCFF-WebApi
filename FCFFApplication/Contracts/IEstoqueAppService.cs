using FCFFApplication.ViewModels.Estoques;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.Contracts
{
    /// <summary>
    /// Serviços da Aplicação
    /// </summary>
    public interface IEstoqueAppService
    {
        void Cadastrar(EstoqueCadastroViewModel model);

        void Atualizar(EstoqueEdicaoViewModel model);

        void Excluir(int idEstoque);

        List<EstoqueConsultaViewModel> ConsultarTodos();

        EstoqueConsultaViewModel ConsultarPorId(int idEstoque);

    }
}

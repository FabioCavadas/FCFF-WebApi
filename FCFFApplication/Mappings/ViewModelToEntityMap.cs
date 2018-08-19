using AutoMapper;
using FCFFApplication.ViewModels.Estoques;
using FCFFApplication.ViewModels.Produtos;
using FCFFDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.Mappings
{
    /// <summary>
    /// Classe para mapear troca de dados entre ViewModel e Entidade.
    /// </summary>
    public class ViewModelToEntityMap : Profile
    {
        public ViewModelToEntityMap()
        {
            CreateMap<EstoqueCadastroViewModel, Estoque>();
            CreateMap<EstoqueEdicaoViewModel, Estoque>();

            CreateMap<ProdutoCadastroViewModel, Produto>();
            CreateMap<ProdutoEdicaoViewModel, Produto>();
        }
    }
}

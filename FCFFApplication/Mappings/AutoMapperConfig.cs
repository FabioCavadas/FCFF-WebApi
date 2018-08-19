using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCFFApplication.Mappings
{
    public class AutoMapperConfig
    {
        /// <summary>
        /// Classe para registrar mapeamentos feitos com AutoMapper de forma que estes possam ser interpretados no evento Application_Start do projeto Asp.Net contido na classe Global.asax.
        /// </summary>
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<EntityToViewModelMap>();
                cfg.AddProfile<ViewModelToEntityMap>();
            });
        }

    }
}

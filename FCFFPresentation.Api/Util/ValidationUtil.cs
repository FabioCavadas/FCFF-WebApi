using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;

namespace FCFFPresentation.Api.Util
{
    public class ValidationUtil
    {
        /// <summary>
        /// Método estático para retornar as mensagens de erro de validação
        /// </summary>      
        
        public static Hashtable GetErrorMessages(ModelStateDictionary ModelState)
        {
            //declarando o hashtable
            var erros = new Hashtable();

            //varrer o ModelState
            foreach (var state in ModelState)
            {
                //verificar se o elemento contido no ModelState possui erro
                if (state.Value.Errors.Count > 0)
                {
                    //adicionar o erro no hashtable
                    erros[state.Key] = state.Value.Errors.Select(e => e.ErrorMessage).ToList();
                }
            }
            //retornar o hashtable
            return erros;
        }
    }
}
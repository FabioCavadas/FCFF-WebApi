using FCFFApplication.Contracts;
using FCFFApplication.ViewModels.Estoques;
using FCFFPresentation.Api.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FCFFPresentation.Api.Controllers
{
    [RoutePrefix("api/estoque")]
    public class EstoqueController : ApiController
    {
        private readonly IEstoqueAppService appService;

        public EstoqueController(IEstoqueAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(EstoqueCadastroViewModel model)
        {
            //verificar se os dados da Model estão válidos
            if (ModelState.IsValid)
            {
                try
                {
                    //realiza o cadastro
                    appService.Cadastrar(model);

                    //retornar status de sucesso HTTP 200
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception e)
                {
                    //retorna erro HTTP 500 (Erro Interno de Servidor)
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                //retorna erro HTTP 400 (Erro de Requisição Inválida)
                return Request.CreateResponse(HttpStatusCode.BadRequest, ValidationUtil.GetErrorMessages(ModelState));
            }
        }

        [HttpPut]
        [Route("atualizar")]
        public HttpResponseMessage Put(EstoqueEdicaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    appService.Atualizar(model);

                    //HTTP 200
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                catch (Exception e)
                {
                    //HTTP 500
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                //HTTP 400 
                return Request.CreateResponse(HttpStatusCode.BadRequest, ValidationUtil.GetErrorMessages(ModelState));
            }
        }
    

        [HttpDelete]
        [Route("excluir")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var estoque = appService.ConsultarPorId(id);

                if(estoque != null)
                {
                    appService.Excluir(id);

                    return Request.CreateResponse(HttpStatusCode.OK, estoque);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);

            }
        }

        [HttpGet]
        [Route("consultar")]
        public HttpResponseMessage GetAll()
        {
            try
            {
                var lista = appService.ConsultarTodos();

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpGet]
        [Route("obter")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var estoque = appService.ConsultarPorId(id);

                if (estoque != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, estoque);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);

            }
        }
    }
}

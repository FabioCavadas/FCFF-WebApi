using FCFFApplication.Contracts;
using FCFFApplication.ViewModels.Produtos;
using FCFFPresentation.Api.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FCFFPresentation.Api.Controllers
{
    [RoutePrefix("api/produto")]
    public class ProdutoController : ApiController
    {
        private readonly IProdutoAppService appService;
        
        public ProdutoController(IProdutoAppService appService)
        {
            this.appService = appService;
        }

        [HttpPost]
        [Route("cadastrar")]
        public HttpResponseMessage Post(ProdutoCadastroViewModel model)
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
        public HttpResponseMessage Put(ProdutoEdicaoViewModel model)
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
                var produto = appService.ConsultarPorId(id);

                if (produto != null)
                {
                    appService.Excluir(id);

                    return Request.CreateResponse(HttpStatusCode.OK, produto);
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
                var produto = appService.ConsultarPorId(id);

                if (produto != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, produto);
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

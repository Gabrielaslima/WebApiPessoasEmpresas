using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiExercicio.Models;
using WebApiExercicio.Repository;
using WebApiExercicio.Validators;

namespace WebApiExercicio.Controllers
{
    [RoutePrefix("api/dados")]
    public class PessoaEmpresaController : ApiController
    {
        public object CpfCnpjUtil { get; private set; }

        [Route("pessoas")]
        [HttpGet]
        public HttpResponseMessage GetPessoas()
        {

            var pessoas = PessoaContexto.ConsultarTodos();

            return Request.CreateResponse(HttpStatusCode.OK, pessoas);

        }

        [Route("empresas")]
        [HttpGet]
        public HttpResponseMessage GetEmpresas()
        {

            var empresas = EmpresaContexto.ConsultarTodos();

            return Request.CreateResponse(HttpStatusCode.OK, empresas);

        }

        [Route("pessoasPost")]
        [HttpPost]
        public HttpResponseMessage PostPessoa([FromBody]Pessoa pessoa)
        {
            if (CpfCnpjUtils.IsValid(pessoa.Cpf))
            {
                PessoaContexto.Add(pessoa);
                return Request.CreateResponse(HttpStatusCode.Created, PessoaContexto.ConsultarTodos());
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "CPF Invalido!");
        }

        [Route("empresasPost")]
        [HttpPost]
        public HttpResponseMessage PostEmpresa([FromBody]Empresa empresa)
        {
            if (CpfCnpjUtils.IsValid(empresa.Cnpj))
            {
                EmpresaContexto.Add(empresa);
                return Request.CreateResponse(HttpStatusCode.Created, EmpresaContexto.ConsultarTodos());
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "CNPJ Invalido!");
        }

    }
}

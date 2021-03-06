using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class DepartamentoController : ApiController
    {
        // GET api/departamento
        [Route("api/departamento")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Departamento.GetAllEF();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // GET api/departamento/5
        [Route("api/departamento/{IdDepartamento}")]
        [HttpGet]
        public IHttpActionResult Get(int IdDepartamento)
        {
            ML.Departamento departamento = new ML.Departamento();
            departamento.IdDepartamento = IdDepartamento;
            ML.Result result = BL.Departamento.GetByIdEF(departamento);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // POST api/departamento
        [Route("api/departamento")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.AddEF(departamento);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // PUT api/departamento/5
        [Route("api/departamento/{IdDepartamento}")]
        [HttpPut]
        public IHttpActionResult Put(int IdDepartamento, [FromBody]ML.Departamento departamento)
        {
            departamento.IdDepartamento = IdDepartamento;
            ML.Result result = BL.Departamento.UpdateEF(departamento);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }

        // DELETE api/departamento/5
        [Route("api/departamento/{IdDepartamento}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdDepartamento)
        {
            ML.Departamento departamento = new ML.Departamento();
            departamento.IdDepartamento = IdDepartamento;
            ML.Result result = BL.Departamento.DeleteEF(departamento);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }
        }
    }
}

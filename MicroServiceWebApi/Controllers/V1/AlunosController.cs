using MicroServiceWebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MicroServiceWebApi.Controllers.V1
{
    [RoutePrefix("api/{apiVersion:apiVersionConstraint(v1)}/alunos")]
    //[UnitOfWorkActionFilter]
    public class AlunosController : ApiController
    {

        //http://bitoftech.net/2014/06/01/token-based-authentication-asp-net-web-api-2-owin-asp-net-identity/

        public IList<Aluno> _mockDb = new List<Aluno> {
            new Aluno { AlunoId = 251, Nome = "Renato Rodrigo Costa", Idade = 22, CPF = "304.723.970-36", DataNascimento = Convert.ToDateTime("27/05/1994") },
            new Aluno { AlunoId = 350, Nome = "Kevin Murilo Souza", Idade= 22, CPF = "109.797.254-29", DataNascimento = Convert.ToDateTime("21/08/1994") },
            new Aluno { AlunoId = 125, Nome = "Laura Maitê Mendes", Idade= 30, CPF = "472.804.186-78", DataNascimento = Convert.ToDateTime("15/12/1986") },
            new Aluno { AlunoId = 152, Nome = "Rodrigo Iago Dias", Idade= 35, CPF = "377.561.522-98", DataNascimento = Convert.ToDateTime("01/04/1981") },
            new Aluno { AlunoId = 052, Nome = "Mariane Larissa Sophie Gomes", Idade = 27, CPF = "397.909.530-46", DataNascimento = Convert.ToDateTime("12/06/1989") },
        };

        [AllowAnonymous]
        //[Route("Register")]
        public IEnumerable<Aluno> Get()
        {
            return _mockDb;
        }

        [HttpGet()]
        [Route("{id:int:min(1)}")]
        [Route("{id:int:min(1)}", Name = "GetAlunoId")]
        public IHttpActionResult Get(int id) {

            var aluno = _mockDb.First(a => a.AlunoId == id);

            if (aluno == null) return NotFound();

            return Ok(aluno);
        }

        [HttpGet()]
        [Route("{id}/pendencia")]
        public IHttpActionResult Pendencia(int id)
        {

            var aluno = _mockDb.First(a => a.AlunoId == id);

            if (aluno == null) return NotFound();

            return Ok(aluno);
        }


        [HttpPost()]
        public IHttpActionResult Post(Aluno aluno)
        {

            if (aluno == null) return BadRequest("Argument Null");

            var companyExists = _mockDb.Any(a => a.AlunoId == aluno.AlunoId);

            if (companyExists) return BadRequest("Exists");

            _mockDb.Add(aluno);

            return Ok();
        }

        [HttpPut()]
        public IHttpActionResult Put(Aluno aluno)
        {
            if (aluno == null) return BadRequest("Argument Null");

            var existing = _mockDb.FirstOrDefault(a => a.AlunoId == aluno.AlunoId);

            if (existing == null) return NotFound();

            existing.Nome = aluno.Nome;

            return Ok();
        }

        [HttpDelete()]
        public IHttpActionResult Delete(int id)
        {
            var aluno = _mockDb.FirstOrDefault(a => a.AlunoId == id);

            if (aluno == null) return NotFound();

            _mockDb.Remove(aluno);

            return Ok();
        }
    }
}

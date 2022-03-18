using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiCadastroPessoa.Models;
using ApiCadastroPessoa.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiCadastroPessoa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoasController : ControllerBase
    {
        private IPessoaService _service;

        public PessoasController(IPessoaService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Adicionar(PessoaModel pessoa)
        {
            _service.Adicionar(pessoa);
            return Ok();
        }

        [HttpDelete("{codigoPessoa}")]
        public IActionResult Remover([FromRoute]string codigoPessoa)
        {
            _service.Remover(codigoPessoa);
            return Ok();
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            return Ok(_service.Consultar());
        }
    }
}

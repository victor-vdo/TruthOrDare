using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruthOrDare.Domain.Commands.Truth;
using TruthOrDare.Domain.Contracts.Services;

namespace TruthOrTruth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruthController : ControllerBase
    {
        private readonly ITruthService _truthService;
        public TruthController(ITruthService truthService)
        {
            _truthService = truthService;
        }

        /// <summary>
        /// Transforma uma temperatura em Fahrenheit para o equivalente
        /// nas escalas Celsius e Kelvin.
        /// </summary>
        /// <returns>Objeto contendo valores para uma temperatura
        /// nas escalas Fahrenheit, Celsius e Kelvin.</returns>
        /// 
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var truth = _truthService.GetById(id);
            return Ok(truth);
        }

        [HttpPost("add")]
        public IActionResult Add(TruthAddCommand truth)
        {
            _truthService.Add(truth);
            return Ok("Verdade adicionada com sucesso !");
        }

        [HttpPut("update")]
        public IActionResult UpdatePassword(TruthUpdateCommand command)
        {
            _truthService.Update(command);
            return Ok("Verdade atualizada com sucesso!");
        }

        [HttpDelete("delete")]
        public IActionResult Delete(TruthDeleteCommand command)
        {
            _truthService.Delete(command);
            return Ok("Verdade Deletada com sucesso!");
        }
    }
}

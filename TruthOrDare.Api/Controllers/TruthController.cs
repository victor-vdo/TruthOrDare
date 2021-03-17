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
            if (truth.IsError)
                return BadRequest(truth);
            return Ok(truth);
        }

        [HttpPost("add")]
        public IActionResult Add(TruthAddCommand truth)
        {
            var add = _truthService.Add(truth);
            if (add.IsError)
                return BadRequest(add);
            return Ok(add);
        }

        [HttpPut("update")]
        public IActionResult Update(TruthUpdateCommand command)
        {
            var update = _truthService.Update(command);
            if (update.IsError)
                return BadRequest(update);
            return Ok(update);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(TruthDeleteCommand command)
        {
            var delete = _truthService.Delete(command);
            if (delete.IsError)
                return BadRequest(delete);
            return Ok(delete);
        }
    }
}

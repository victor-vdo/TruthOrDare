using Microsoft.AspNetCore.Mvc;
using System;
using TruthOrDare.Domain.Commands.Dare;
using TruthOrDare.Domain.Contracts.Services;

namespace TruthOrDare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DareController : ControllerBase
    {
        private readonly IDareService _dareService;
        public DareController(IDareService dareService)
        {
            _dareService = dareService;
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
            var dare = _dareService.GetById(id);
            if (!dare.IsError)
                return BadRequest(dare);
            return Ok(dare);
        }

        [HttpGet("type/{type}")]
        public IActionResult GetByType(int type)
        {
            var dare = _dareService.GetByType(type);
            if (!dare.IsError)
                return BadRequest(dare);
            return Ok(dare);
        }

        [HttpPost("add")]
        public IActionResult Add(DareAddCommand dare)
        {
            var add = _dareService.Add(dare);
            if (!add.IsError)
                return BadRequest(add);
            return Ok(add);
        }

        [HttpPut("update")]
        public IActionResult Update(DareUpdateCommand command)
        {
            var update = _dareService.Update(command);
            if (!update.IsError)
                return BadRequest(update);
            return Ok(update);
        }

        [HttpDelete("delete")]
        public IActionResult Delete(DareDeleteCommand command)
        {
            var delete = _dareService.Delete(command);
            if (!delete.IsError)
                return BadRequest(delete);
            return Ok(delete);
        }
    }
}

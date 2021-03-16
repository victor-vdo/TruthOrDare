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
            var user = _dareService.GetById(id);
            return Ok(user);
        }

        [HttpGet("type/{type}")]
        public IActionResult GetByType(int type)
        {
            var user = _dareService.GetByType(type);
            return Ok(user);
        }

        [HttpPost("add")]
        public IActionResult Add(DareAddCommand user)
        {
            _dareService.Add(user);
            return Ok(user);
        }

        [HttpPut("update")]
        public IActionResult UpdatePassword(DareUpdateCommand command)
        {
            _dareService.Update(command);
            return Ok("Senha atualizada com sucesso!");
        }

        [HttpDelete("delete")]
        public IActionResult Delete(DareDeleteCommand command)
        {
            _dareService.Delete(command);
            return Ok("Senha atualizada com sucesso!");
        }
    }
}

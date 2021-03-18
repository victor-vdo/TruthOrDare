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
        /// Busca um Desafio pelo ID.
        /// </summary>
        /// <returns>Objeto contendo valores de um Desafio</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var dare = _dareService.GetById(id);
            if (dare.IsError)
                return BadRequest(dare);
            return Ok(dare);
        }


        /// <summary>
        /// Busca um Desafio pelo Tipo.
        /// </summary>
        /// <returns>Objeto contendo valores de um Desafio</returns>
        [HttpGet("type/{type}")]
        public IActionResult GetByType(int type)
        {
            var dare = _dareService.GetByType(type);
            if (dare.IsError)
                return BadRequest(dare);
            return Ok(dare);
        }

        /// <summary>
        /// Cria um novo Desafio
        /// </summary>
        /// <returns>Adição de um novo Desafio.</returns>
        [HttpPost("add")]
        public IActionResult Add(DareAddCommand dare)
        {
            var add = _dareService.Add(dare);
            if (add.IsError)
                return BadRequest(add);
            return Ok(add);
        }

        /// <summary>
        /// Atualiza um Desafio
        /// </summary>
        /// <returns>Atualização de um Desafio.</returns>
        [HttpPut("update")]
        public IActionResult Update(DareUpdateCommand command)
        {
            var update = _dareService.Update(command);
            if (update.IsError)
                return BadRequest(update);
            return Ok(update);
        }

        /// <summary>
        /// Deleta um Desafio
        /// </summary>
        /// <returns>Remoção de um Desafio.</returns>
        [HttpDelete("delete")]
        public IActionResult Delete(DareDeleteCommand command)
        {
            var delete = _dareService.Delete(command);
            if (delete.IsError)
                return BadRequest(delete);
            return Ok(delete);
        }
    }
}

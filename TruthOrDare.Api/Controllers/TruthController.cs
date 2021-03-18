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
        /// Busca uma verdade pelo ID
        /// </summary>
        /// <returns>Objeto contendo valores de uma Verdade.</returns>
        /// 
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var truth = _truthService.GetById(id);
            if (truth.IsError)
                return BadRequest(truth);
            return Ok(truth);
        }

        /// <summary>
        /// Cria uma nova pergunta Verdade
        /// </summary>
        /// <returns>Adição de uma nova Verdade.</returns>
        [HttpPost("add")]
        public IActionResult Add(TruthAddCommand truth)
        {
            var add = _truthService.Add(truth);
            if (add.IsError)
                return BadRequest(add);
            return Ok(add);
        }

        /// <summary>
        /// Atualiza uma pergunta Verdade
        /// </summary>
        /// <returns>Atualização de uma Verdade.</returns>
        [HttpPut("update")]
        public IActionResult Update(TruthUpdateCommand command)
        {
            var update = _truthService.Update(command);
            if (update.IsError)
                return BadRequest(update);
            return Ok(update);
        }

        /// <summary>
        /// Deleta uma pergunta Verdade
        /// </summary>
        /// <returns>Remoção de uma verdade.</returns>
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

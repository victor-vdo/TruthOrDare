using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TruthOrDare.Domain.Commands.User;
using TruthOrDare.Domain.Contracts.Services;
using TruthOrDare.Domain.Services;

namespace TruthOrDare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Busca um usuário pelo ID
        /// </summary>
        /// <returns>Objeto contendo valores do usuário.</returns>
        
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            if (user.IsError)
                return BadRequest(user);
            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário
        /// </summary>
        /// <returns>Adição de um novo usuário.</returns>
        [HttpPost("add")]
        public IActionResult Add(UserAddCommand user)
        {
            var add =_userService.Add(user);
            if (add.IsError)
                return BadRequest(add);
            return Ok(add);
        }

        /// <summary>
        /// Atualiza a senha de um usuário
        /// </summary>
        /// <returns>Atualização da senha de um usuário.</returns>
        [HttpPut("updatepassword")]
        public IActionResult UpdatePassword(UserUpdatePasswordCommand command)
        {
           var update = _userService.UpdatePassword(command);
            if (update.IsError)
                return BadRequest(update);
            return Ok(update);
        }

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <returns>Remoção de um usuário.</returns>
        [HttpDelete("delete")]
        public IActionResult Delete(UserDeleteCommand command)
        {
            var delete =_userService.Delete(command);
            if (delete.IsError)
                return BadRequest(delete);
            return Ok(delete);
        }
    }
}

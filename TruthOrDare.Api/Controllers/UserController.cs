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
        /// Transforma uma temperatura em Fahrenheit para o equivalente
        /// nas escalas Celsius e Kelvin.
        /// </summary>
        /// <returns>Objeto contendo valores para uma temperatura
        /// nas escalas Fahrenheit, Celsius e Kelvin.</returns>
        /// 
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPost("add")]
        public IActionResult AddUser(UserAddCommand user)
        {
            _userService.Add(user);
            return Ok(user);
        }

    }
}

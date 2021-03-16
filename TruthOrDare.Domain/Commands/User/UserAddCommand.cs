using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDare.Domain.Commands.User
{
    public class UserAddCommand
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDare.Domain.Commands.User
{
    public class UserUpdatePasswordCommand
    {
        public Guid Id { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}

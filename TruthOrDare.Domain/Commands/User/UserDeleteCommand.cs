using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDare.Domain.Commands.User
{
    public class UserDeleteCommand
    {
        public Guid Id { get; set; }
    }
}

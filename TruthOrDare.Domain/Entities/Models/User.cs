using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDare.Domain.Entities.Models
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TruthOrDare.Domain.Enums;

namespace TruthOrDare.Domain.Entities.Models
{
    public class Dare : Entity
    {
        public ETruthOrDareType Type { get; set; }
        public string Description { get; set; }
    }
}

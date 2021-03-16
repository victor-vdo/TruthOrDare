using System;
using TruthOrDare.Domain.Enums;

namespace TruthOrDare.Domain.Commands.Dare
{
    public class DareUpdateCommand
    {
        public Guid Id { get; set; }
        public ETruthOrDareType Type { get; set; }
        public string Description { get; set; }
    }
}

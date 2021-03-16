using System;
using TruthOrDare.Domain.Enums;

namespace TruthOrDare.Domain.Commands.Truth
{
    public class TruthUpdateCommand
    {
        public Guid Id { get; set; }
        public ETruthOrDareType Type { get; set; }
        public string Description { get; set; }
    }
}

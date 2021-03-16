using TruthOrDare.Domain.Enums;

namespace TruthOrDare.Domain.Commands.Truth
{
    public class TruthAddCommand
    {
        public ETruthOrDareType Type { get; set; }
        public string Description { get; set; }
    }
}

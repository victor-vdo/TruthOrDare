using TruthOrDare.Domain.Enums;

namespace TruthOrDare.Domain.Commands.Dare
{
    public class DareAddCommand
    {
        public ETruthOrDareType Type { get; set; }
        public string Description { get; set; }
    }
}

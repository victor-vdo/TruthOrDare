using TruthOrDare.Domain.Enums;

namespace TruthOrDare.Domain.Commands.Dare
{
    public class DareGetByTypeCommand
    {
        public ETruthOrDareType Type { get; set; }
    }
}

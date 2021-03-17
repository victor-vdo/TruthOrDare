using TruthOrDare.Domain.Contracts;

namespace TruthOrDare.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(string message, object data, bool isError)
        {
            Message = message;
            Data = data;
            IsError = isError;
        }
        public string Message { get; set; }
        public object Data { get; set; }
        public bool IsError { get; set; }
    }
}

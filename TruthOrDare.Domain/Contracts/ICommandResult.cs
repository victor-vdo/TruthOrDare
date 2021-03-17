using System;
using System.Collections.Generic;
using System.Text;

namespace TruthOrDare.Domain.Contracts
{
    public interface ICommandResult
    {
        public string Message { get; set; }
        public object Data { get; set; }
        public bool IsError { get; set; }

    }
}

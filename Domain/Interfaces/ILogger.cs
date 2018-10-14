using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Interfaces
{
    public interface ILogger
    {
        void Info(string message, Dictionary<string, object> otherProperties);
        void Debug(string message, Dictionary<string, object> otherProperties);
        void Error(string message, Dictionary<string, object> otherProperties, Exception exception);
    }
}

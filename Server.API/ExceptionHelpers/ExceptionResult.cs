using System.Text.Json.Serialization;

namespace Server.API.ExceptionHelpers
{
    public class ExceptionResult
    {
        public string ExceptionMessage { get; set; }
        
        public ResultType ResultType { get; set; }
    }
}

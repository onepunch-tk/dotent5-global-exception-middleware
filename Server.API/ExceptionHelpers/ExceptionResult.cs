using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Server.API.ExceptionHelpers
{
    public class ExceptionResult
    {
        public string ExceptionMessage { get; set; }
        
        [JsonIgnore]
        public ResultType ResultType { get; set; }
    }
}

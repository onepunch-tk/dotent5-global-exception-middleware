using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Models
{
    public class ResponseMessage<T>
    {
        public T ResponseData { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Server.API.Models
{
    public class TestResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}

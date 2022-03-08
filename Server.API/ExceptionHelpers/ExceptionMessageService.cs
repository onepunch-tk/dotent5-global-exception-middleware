using Newtonsoft.Json.Linq;
using System;
using System.Net;
using System.Text.Json;

namespace Server.API.ExceptionHelpers
{
    /// <summary>
    /// Exception Result Message Service
    /// </summary>
    public class ExceptionMessageService
    {
        public string Serializer(ExceptionResult result) => JsonSerializer.Serialize(result);
        public string Serializer<T>(string message) => JsonSerializer.Serialize(message);
        public ExceptionResult DeSerializer(string message) => JsonSerializer.Deserialize<ExceptionResult>(message);
        
        public HttpStatusCode GetStatusCode(string message)
        {
            JsonParse(message, out ResultType resultType);

            switch (resultType)
            {
                case ResultType.NotFound:
                    return HttpStatusCode.NotFound;

                case ResultType.Forbid:
                    return HttpStatusCode.Forbidden;

                case ResultType.Conflict:
                    return HttpStatusCode.Conflict;

                case ResultType.BadRequest:
                    return HttpStatusCode.BadRequest;
                
                case ResultType.Unauthorized:
                    return HttpStatusCode.Unauthorized;

                default:
                    throw new Exception();
            }
        }

        private void JsonParse(string message, out ResultType resultType)
        {
            JObject json = JObject.Parse(message);
            resultType = (ResultType)json.Value<int> ("ResultType");
        }
    }
}

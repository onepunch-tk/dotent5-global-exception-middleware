using Microsoft.AspNetCore.Http;
using Server.API.ExceptionHelpers;
using System.Linq;
using System.Threading.Tasks;

namespace Server.API.Authorization
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ExceptionMessageService _messageService;

        public JwtMiddleware(RequestDelegate next, ExceptionMessageService messageService)
        {
            _next = next;
            _messageService = messageService;
        }

        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
                throw new CustomAppExeption(_messageService.Serializer(new ExceptionResult {ExceptionMessage="Unauthorized", ResultType=ResultType.Unauthorized }));
        }
    }
}

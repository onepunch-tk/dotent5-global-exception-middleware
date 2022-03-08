using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Server.API.ExceptionHelpers
{
    /// <summary>
    /// Global excepion handler middleware
    /// 모든 예외처리를 이곳에서 캐치하여 반환할 Http ResponseCode를 결정
    /// </summary>
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ExceptionMessageService _messageService;

        public ExceptionHandlerMiddleware(RequestDelegate next, ExceptionMessageService messageService)
        {
            _next = next;
            _messageService = messageService;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception apiExeption)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                //excepion 종류를 캐치한다
                //비지니스 로직에 따라 exception type을 추가 한다.
                switch (apiExeption)
                {
                    //사용자 정의 exception 모델
                    case CustomAppExeption:
                        response.StatusCode = (int)_messageService.GetStatusCode(apiExeption.Message);
                        break;
                    case KeyNotFoundException:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    default:
                        //그외 예외 메세지
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }
                
                
                await response.WriteAsJsonAsync(_messageService.DeSerializer(apiExeption.Message));
            }
        }
    }
}

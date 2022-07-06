using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Errors
{
    public class CodeErrorResponse
    {
        public CodeErrorResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageStatusCode(statusCode);
        }

        private string GetDefaultMessageStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "The submitted request has errors",                    //"El Request enviado tiene errores"
                401 => "You are not authorized for this resource",           //No tienes autorizacion para este recurso
                404 => "The searched item was not found",                   //No se encontro el item buscado
                500 => "server errors occurred",                           //se producieron errores en el servidor
                _ => null
            };
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}

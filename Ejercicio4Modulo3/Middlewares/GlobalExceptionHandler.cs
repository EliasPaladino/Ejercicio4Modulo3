
using Ejercicio4Modulo3.Domain.Entities;
using Ejercicio4Modulo3.Repository;
using System.ComponentModel.DataAnnotations;

namespace Ejercicio4Modulo3.Middlewares
{
    public class GlobalExceptionHandler : IMiddleware
    {

        private Clase4Modulo3Context _context;
        public GlobalExceptionHandler(Clase4Modulo3Context context)
        {
            _context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);

                if (context.Response.StatusCode.Equals(200))
                {
                    await _context.Logs.AddAsync(new Logs
                    {
                        Fecha = DateTime.Now,
                        Path = context.Request.Path.Value,
                        Method = context.Request.Method,
                        Success = true,
                    });
                    await _context.SaveChangesAsync();
                }
                else
                {
                    await _context.Logs.AddAsync(new Logs
                    {
                        Fecha = DateTime.Now,
                        Path = context.Request.Path.Value,
                        Method = context.Request.Method,
                        Success = false,
                    });
                    await _context.SaveChangesAsync();
                }
            }
            catch (ValidationException ex)
            {
                context.Response.StatusCode = 400;
                context.Response.ContentType = "application/json";

                var respuesta = new
                {
                    Error = $"Error en la validacion de la API {context.Request.Path.Value} {context.Request.Method}"
                };

                await context.Response.WriteAsJsonAsync(respuesta);
            }
        }
    }
}

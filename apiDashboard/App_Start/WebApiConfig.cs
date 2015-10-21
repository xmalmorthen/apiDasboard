using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Mvc;

namespace apiDashboard
{
    public static class WebApiConfig
    {
        public static Stopwatch stopWatch;
        public static Dictionary<string, string> DbCnnCnfg = new Dictionary<string, string>();

        public static void Register(HttpConfiguration config)
        {
            stopWatch = new Stopwatch();
            stopWatch.Start();

            config.Routes.MapHttpRoute(
                 "ApiDefault",
                 "{controller}/{action}/{query}",
                 new
                 {
                     query = UrlParameter.Optional, 
                 },
                 new { httpMethod = new HttpMethodConstraint(System.Net.Http.HttpMethod.Get) }
            );

            // Quite los comentarios de la siguiente línea de código para habilitar la compatibilidad de consultas para las acciones con un tipo de valor devuelto IQueryable o IQueryable<T>.
            // Para evitar el procesamiento de consultas inesperadas o malintencionadas, use la configuración de validación en QueryableAttribute para validar las consultas entrantes.
            // Para obtener más información, visite http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();

            // Para deshabilitar el seguimiento en la aplicación, incluya un comentario o quite la siguiente línea de código
            // Para obtener más información, consulte: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();
        }
    }
}

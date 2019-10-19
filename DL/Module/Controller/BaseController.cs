using System;
using Micron.DL.Middleware;
using Micron.DL.Module.Http;
using Nancy;

namespace Micron.DL.Module.Controller {
    public abstract class BaseController : NancyModule {
        protected ProcessedRequest CurrentRequest { get; set; }

        protected abstract IMiddleware[] Middleware();

        public BaseController() {
            Before += ctx => {
                CurrentRequest = new ProcessedRequest(Request);

                var middlewareError = MiddlewareProcessor.Process(CurrentRequest, Middleware());

                if (middlewareError != null) {
                    return HttpResponse.Error(middlewareError);
                }
                
                return null;
            };
        }

        protected string GetStringFromRequest(string parameter) => (string) Request.Query[parameter];
        
        protected int GetIntFromRequest(string parameter) => (int) Request.Query[parameter];
        
        protected Enum GetEnumFromRequest(string parameter, Type enumType) {
            return (Enum) Enum.Parse(enumType, Request.Query[parameter], true);
        }
    }
}
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

        protected string GetRequestStr(string parameter) => CurrentRequest.GetRequestStr(parameter);
        
        protected int GetRequestInt(string parameter) => CurrentRequest.GetRequestInt(parameter);
        
        protected Enum GetRequestEnum(string parameter, Type enumType) {
            return CurrentRequest.GetRequestEnum(parameter, enumType);
        }
    }
}
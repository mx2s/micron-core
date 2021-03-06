using Micron.DL.Middleware;
using Micron.DL.Module.Http;
using Micron.DL.Module.Validator;
using Nancy;

namespace Micron.DL.Module.Controller {
    public static class ControllerProcessor {
        public static ProcessedRequest ProcessAll(Request request, IMiddleware[] middleware, IValidatorRule[] rules) {
            var processed = new ProcessedRequest(request);

            foreach (var mid in middleware) {
                mid.Process(processed);
                if (processed.HasErrors()) {
                    return processed;
                }
            }

            foreach (var rule in rules) {
                var result = rule.Process(processed.Request);
                if (result != null) {
                    processed.AddError(result);
                }
            }
            
            return processed;
        }
    }
}
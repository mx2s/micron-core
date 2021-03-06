using Micron.DL.Module.Http;
using Micron.DL.Module.Validator;
using Nancy;

namespace Micron.AL.Validation.Basic {
    public class ShouldHaveParameter : IValidatorRule {
        public string Parameter { get; }

        public ShouldHaveParameter(string param) {
            Parameter = param;
        }
        
        public HttpError Process(Request request) {
            var val = (string) request.Query[Parameter];

            if (val == null) {
                return new HttpError(
                    HttpStatusCode.UnprocessableEntity,
                    $"Parameter '{Parameter}' is required", Parameter
                );
            }
            
            return null;
        }
    }
}
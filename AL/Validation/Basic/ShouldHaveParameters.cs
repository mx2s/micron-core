using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Module.Validator;
using Nancy;

namespace BaseFramework.AL.Validation.Basic {
    public class ShouldHaveParameters : IValidatorRule {
        private string[] Parameters { get; }

        public ShouldHaveParameters(string[] parameters) {
            Parameters = parameters;
        }
        
        public HttpError Process(Request request) {
            foreach (var param in Parameters) {
                var error = new ShouldHaveParameter(param).Process(request);
                if (error != null) {
                    return error;
                }
            }
            
            return null;
        }
    }
}
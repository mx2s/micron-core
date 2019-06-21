using System.Text.RegularExpressions;
using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Module.Validator;
using Nancy;

namespace BaseFramework.AL.Validation.String {
    public class HasLetters : IValidatorRule {
        public string Parameter { get; }
        
        public HasLetters(string parameter) {
            Parameter = parameter;
        }

        public HttpError Process(Request request) {
            var val = (string) request.Query[Parameter];

            if (!Regex.IsMatch(val, @"^[a-zA-Z]+$")) {
                return new HttpError(
                    HttpStatusCode.UnprocessableEntity,
                    $"{Parameter} should have characters", Parameter
                );
            }

            return null;
        }
    }
}
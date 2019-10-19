using System.Text.RegularExpressions;
using Micron.DL.Module.Http;
using Micron.DL.Module.Validator;
using Nancy;

namespace Micron.AL.Validation.String {
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
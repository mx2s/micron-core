using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Module.Validator;
using Nancy;

namespace BaseFramework.AL.Validation.String {
    public class MinLength : IValidatorRule {
        public string Parameter { get; }

        private readonly ushort _minLength;
        
        public MinLength(string parameter, ushort minLength) {
            Parameter = parameter;
            _minLength = minLength;
        }

        public HttpError Process(Request request) {
            var val = (string) request.Query[Parameter];

            if (val.Length < _minLength) {
                return new HttpError(
                    HttpStatusCode.UnprocessableEntity,
                    $"{Parameter} should be longer than {_minLength} characters", Parameter
                );
            }

            return null;
        }
    }
}
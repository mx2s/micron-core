using System;
using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Module.Validator;
using Nancy;

namespace BaseFramework.AL.Validation.String {
    public class ShouldBeCorrectEnumValue : IValidatorRule {
        public string Parameter { get; }

        private Type EnumType { get; }

        public ShouldBeCorrectEnumValue(string parameter, Type enumType) {
            Parameter = parameter;
            EnumType = enumType;
        }

        public HttpError Process(Request request) {
            var val = (string) request.Query[Parameter];
            var result = Enum.TryParse(EnumType, (string) request.Query[Parameter], true, out _);
            
            if (!result) {
                return new HttpError(
                    HttpStatusCode.UnprocessableEntity,
                    $"{Parameter} can only have these values: " + string.Join(", ", Enum.GetNames(EnumType)), Parameter
                );
            }

            return null;
        }
    }
}
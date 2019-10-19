using System;
using Micron.DL.Module.Http;
using Micron.DL.Module.Validator;
using Nancy;

namespace Micron.AL.Validation.String {
    public class ShouldBeCorrectEnumValue : IValidatorRule {
        public string Parameter { get; }

        private Type EnumType { get; }

        public ShouldBeCorrectEnumValue(string parameter, Type enumType) {
            Parameter = parameter;
            EnumType = enumType;
        }

        public HttpError Process(Request request) {
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
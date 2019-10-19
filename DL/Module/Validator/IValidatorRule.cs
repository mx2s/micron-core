using Micron.DL.Module.Http;
using Nancy;

namespace Micron.DL.Module.Validator {
    public interface IValidatorRule {
        HttpError Process(Request request);
    }
}
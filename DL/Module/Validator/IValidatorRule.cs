using BaseFramework.DL.Module.Http;
using Nancy;

namespace BaseFramework.DL.Module.Validator {
    public interface IValidatorRule {
        HttpError Process(Request request);
    }
}
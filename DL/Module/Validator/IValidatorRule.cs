using BaseFramework.DL.Module.Http;
using Nancy;
using Newtonsoft.Json.Linq;

namespace BaseFramework.DL.Module.Validator {
    public interface IValidatorRule {
        string Parameter { get; }
        
        HttpError Process(Request request);
    }
}
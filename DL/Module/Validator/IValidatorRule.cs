using Core.DL.Module.Http;
using Nancy;
using Newtonsoft.Json.Linq;

namespace BaseFramework.DL.Module.Validator {
    public interface IValidatorRule {
        string Parameter { get; }

        JObject Custom { get; }
        
        HttpError Process(Request request);
    }
}
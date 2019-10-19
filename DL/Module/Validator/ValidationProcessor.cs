using System.Collections.Generic;
using Micron.DL.Module.Http;
using Nancy;

namespace Micron.DL.Module.Validator {
    public static class ValidationProcessor {
        public static List<HttpError> Process(
            Request request, IEnumerable<IValidatorRule> rules, bool returnFirst = false
        ) {
            var list = new List<HttpError>();
            
            foreach (var rule in rules) {
                var error = rule.Process(request);
                if (error != null) {
                    list.Add(error);
                    if (returnFirst) {
                        return list;
                    }
                }
            }
            
            return list;
        }
    }
}
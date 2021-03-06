using System.Collections.Generic;
using System.Linq;
using Micron.PL.Transformer.Http;
using Nancy;
using Newtonsoft.Json.Linq;

namespace Micron.DL.Module.Http {
    public static class HttpResponse {
        public static Response Data(JObject data, HttpStatusCode statusCode = HttpStatusCode.OK) {
            var response = (Response) new JObject() {
                ["data"] = data
            }.ToString();
            response.StatusCode = statusCode;
            return response;
        }

        public static Response Item(string key, JObject data,
            HttpStatusCode statusCode = HttpStatusCode.OK) {
            var response = (Response) new JObject() {
                ["data"] = new JObject() {
                    [key] = data
                }
            }.ToString();
            response.StatusCode = statusCode;
            return response;
        }

        public static Response Item(string key, JArray data,
            HttpStatusCode statusCode = HttpStatusCode.OK) {
            var response = (Response) new JObject() {
                ["data"] = new JObject() {
                    [key] = data
                }
            }.ToString();
            response.StatusCode = statusCode;
            return response;
        }

        public static Response Error(HttpStatusCode code, string message, JObject metadata = null) {
            var jobj = new JObject() {
                ["errors"] = new HttpErrorTransformer().Many(
                    new[] {new HttpError(code, message)}
                )
            };
            if (metadata != null) {
                jobj["metadata"] = metadata;
            }
            
            var response = (Response) jobj.ToString();
            response.StatusCode = code;
            return response;
        }

        public static Response Error(HttpError err) => Error(err.StatusCode, err.Message);
        
        public static Response Errors(IEnumerable<HttpError> errors) {
            var response = (Response) new JObject() {
                ["errors"] = new HttpErrorTransformer().Many(errors)
            }.ToString();
            response.StatusCode = errors.First().StatusCode;
            return response;
        }
    }
}
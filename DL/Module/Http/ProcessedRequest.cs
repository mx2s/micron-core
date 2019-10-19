using System.Collections.Generic;
using System.Linq;
using Nancy;

namespace Micron.DL.Module.Http {
    public class ProcessedRequest {
        public Request Request { get; }
        public List<HttpError> Errors { get; }
        
        public int UserId { get; set; }

        public Response Response { get; set; }

        public ProcessedRequest(Request request) {
            Request = request;
            Errors = new List<HttpError>();
        }

        public bool HasErrors() => Errors.Count > 0;

        public HttpError FirstError => Errors.First();

        public void AddError(HttpError error) => Errors.Add(error);
    }
}
using System;
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

        public string GetParamStr(string parameter) => (string) Request.Query[parameter];
        public int GetParamInt(string parameter) => (int) Request.Query[parameter];
        
        protected Enum GetRequestEnum(string parameter, Type enumType) {
            return (Enum) Enum.Parse(enumType, Request.Query[parameter], true);
        }
    }
}
using Micron.DL.Module.Http;

namespace Micron.DL.Middleware {
    public static class MiddlewareProcessor {
        public static HttpError Process(ProcessedRequest request, IMiddleware[] middleware) {
            foreach (var m in middleware) {
                m.Process(request);
                if (request.HasErrors()) {
                    return request.FirstError;
                }
            }
            return null;
        }
    }
}
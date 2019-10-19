using Micron.DL.Module.Http;

namespace Micron.DL.Middleware {
    public interface IMiddleware {
        ProcessedRequest Process(ProcessedRequest request);
    }
}
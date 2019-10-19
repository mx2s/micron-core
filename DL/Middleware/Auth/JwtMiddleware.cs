using Micron.DL.Module.Auth;
using Micron.DL.Module.Http;
using Nancy;

namespace Micron.DL.Middleware.Auth {
    public class JwtMiddleware : IMiddleware {
        public ProcessedRequest Process(ProcessedRequest request) {
            var userId = Jwt.GetUserIdFromToken((string) request.Request.Query["api_token"] ?? "");
            
            if (userId == 0) {
                request.AddError(
                    new HttpError(HttpStatusCode.Unauthorized, "Invalid api_token")
                );
            }

            request.UserId = userId;

            return request;
        }
    }
}
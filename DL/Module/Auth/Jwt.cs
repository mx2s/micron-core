using System;
using System.Collections.Generic;
using JWT.Algorithms;
using JWT.Builder;
using Micron.DL.Module.Config;

namespace Micron.DL.Module.Auth {
    public static class Jwt {
        public static string FromUserId(int userId) {
            var days = AppConfig.Get().GetJwtLifeDays();
            return new JwtBuilder()
                .WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(AppConfig.Get().GetJwtSecretKey())
                .AddClaim(
                    "exp",
                    DateTimeOffset.UtcNow.AddDays(days).ToUnixTimeSeconds()
                )
                .AddClaim("user_id", userId)
                .Build();
        }

        public static int GetUserIdFromToken(string token) {
            try {
                return Convert.ToInt32(new JwtBuilder()
                    .WithSecret(AppConfig.Get().GetJwtSecretKey())
                    .MustVerifySignature()
                    .Decode<IDictionary<string, object>>(token)["user_id"]);
            }
            catch (Exception e) {
                // ignored
            }
            return 0;
        }
    }
}
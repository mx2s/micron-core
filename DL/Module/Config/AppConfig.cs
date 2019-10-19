using System;
using Microsoft.Extensions.Configuration;

namespace Micron.DL.Module.Config {
    public class AppConfig {
        private readonly string _dbHost;
        private readonly int _dbPort;
        private readonly string _dbUser;
        private readonly string _dbPassword;
        private readonly string _dbName;

        private readonly string _jwtSecretKey;
        private readonly int _jwtTokenLifeDays;

        private readonly string _encryptionKey;
        
        private static AppConfig _instance;

        private readonly IConfigurationRoot _configData;

        private AppConfig() {
            _configData = new ConfigurationBuilder()
                .AddJsonFile("config/config.json")
                .Build();
            _jwtSecretKey = _configData["auth:jwt:secret_key"];
            _jwtTokenLifeDays = Convert.ToInt32(_configData["auth:jwt:token_life_days"]);

            _encryptionKey = _configData["auth:encryption_key"];
            
            _dbName = _configData["database:name"]; 
            _dbHost = _configData["database:host"];
            _dbPort = Convert.ToInt32(_configData["database:port"]);
            _dbUser = _configData["database:user"];
            _dbPassword = _configData["database:password"];
        }

        public static AppConfig Get() {
            if (_instance == null) {
                _instance = new AppConfig();
            }
            return _instance;
        }
        
        public static string GetConfiguration(string key) => Get()._configData[key];

        public string GetConnectionString() 
            => $"Host={_dbHost};Port={_dbPort};Username={_dbUser};Password={_dbPassword};Database={_dbName}";

        public string GetJwtSecretKey() => _jwtSecretKey;
        
        public int GetJwtLifeDays() => _jwtTokenLifeDays;
        
        public string GetEncryptionKey() => _encryptionKey;
    }
}
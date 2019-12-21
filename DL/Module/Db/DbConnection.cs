using System.Data;
using Micron.DL.Module.Config;
using Npgsql;

namespace Micron.DL.Module.Db {
    public class DbConnection {
        private IDbConnection _connection;

        private IDbTransaction _lastTransaction;
        
        private static DbConnection _instance;
        
        private DbConnection() {
            ReConnect();
        }

        public IDbConnection ReConnect() {
            _connection = new NpgsqlConnection(AppConfig.Get().GetConnectionString()); 
            _connection.Open();
            return _connection;
        }

        public static DbConnection Get() {
            if (_instance == null) {
                return _instance = new DbConnection();
            }
            return _instance;
        }

        public static IDbTransaction BeginTransaction() {
            var newTx = Get()._connection.BeginTransaction();
            Get()._lastTransaction = newTx;
            return newTx;
        }
        
        public static void RollbackTransaction() {
            Get()._lastTransaction.Rollback();
        }

        public static IDbConnection Connection() => new NpgsqlConnection(AppConfig.Get().GetConnectionString());

        public static IDbConnection RootConnection() => Get()._connection;
    }
}
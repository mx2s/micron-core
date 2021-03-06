using System.Data;
using System.Linq;
using Dapper;
using Micron.DL.Module.Db;

namespace Micron.DL.Model {
    public abstract class Model {
        protected static IDbConnection Connection() => DbConnection.Connection();

        protected static int QueryInt(string sql, object parameters) => Connection().Query<int>(sql, parameters).Single();
        
        protected static void ExecuteSql(string sql, object parameters) => Connection().Execute(sql, parameters);

        protected static int ExecuteScalarInt(string sql, object parameters = null) {
            return Connection().ExecuteScalar<int>(sql, parameters ?? new {});
        }
    }
}
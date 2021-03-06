using Dapper;
using Micron.DL.Module.Db;
using Micron.DL.Module.Http;
using Micron.DL.Module.Validator;
using Nancy;
using Newtonsoft.Json.Linq;

namespace Micron.AL.Validation.Db {
    public class ExistsInTable : IValidatorRule {
        public string Parameter { get; }

        public JObject Custom { get; }

        public ExistsInTable(string parameter, string table, string column = null) {
            column = column ?? parameter;
            Parameter = parameter;
            Custom = new JObject() {
                ["table"] = table,
                ["column"] = column
            };
        }

        public HttpError Process(Request request) {
            var val = (string) request.Query[Parameter];

            var result = DbConnection.Connection().ExecuteScalar<bool>(
                $"SELECT COUNT(*) FROM {Custom["table"]} WHERE {Custom["column"]} = @val LIMIT 1",
                new {
                    val
                }
            );

            if (!result) {
                return new HttpError(
                    HttpStatusCode.NotFound,
                    $"Entity with specified {Custom["column"]} doesn't exist in table {Custom["table"]}", Parameter
                );
            }

            return null;
        }
    }
}
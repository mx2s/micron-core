using BaseFramework.DL.Module.Http;
using BaseFramework.DL.Module.Validator;
using Core.DL.Module.Db;
using Dapper;
using Nancy;
using Newtonsoft.Json.Linq;

namespace BaseFramework.AL.Validation.Db {
    public class ShouldNotExistInTable : IValidatorRule {
        public string Parameter { get; }

        public JObject Custom { get; }

        public ShouldNotExistInTable(string parameter, string table, string column = null) {
            column = column ?? parameter;
            Parameter = parameter;
            Custom = new JObject() {
                ["table"] = table,
                ["column"] = column
            };
        }

        public HttpError Process(Request request) {
            var val = (string) request.Query[Parameter];

            var result = !DbConnection.Connection().ExecuteScalar<bool>(
                $"SELECT COUNT(*) FROM {Custom["table"]} WHERE {Custom["column"]} = @val LIMIT 1",
                new {
                    val
                }
            );

            if (!result) {
                return new HttpError(
                    HttpStatusCode.UnprocessableEntity,
                    $"Entity with specified {Custom["column"]} already exist in table {Custom["table"]}", 
                    Parameter
                );
            }

            return null;
        }
    }
}
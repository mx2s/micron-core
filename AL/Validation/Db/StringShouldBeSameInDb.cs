using System.Linq;
using Dapper;
using Micron.DL.Module.Db;
using Micron.DL.Module.Http;
using Micron.DL.Module.Validator;
using Nancy;

namespace Micron.AL.Validation.Db {
    public class StringShouldBeSameInDb : IValidatorRule {
        public string Parameter { get; }

        private string _table;

        private string _column;

        private string _columnToCompare;
        
        private string _expectedValue;
        
        public StringShouldBeSameInDb(string parameter, string table, string column, string columnToCompare, string expected) {
            Parameter = parameter;
            _table = table;
            _column = column;
            _columnToCompare = columnToCompare;
            _expectedValue = expected;
        }

        public HttpError Process(Request request) {
            var val = (string) request.Query[Parameter];

            var result = DbConnection.Connection().Query<string>(
                $"SELECT {_columnToCompare} FROM {_table} WHERE {_column} = @val LIMIT 1",
                new {
                    val
                }
            ).FirstOrDefault();
            
            if (result != _expectedValue) {
                return new HttpError(
                    HttpStatusCode.Forbidden,
                    "You cannot perform this action, validator: " + this.GetType().Name, Parameter
                );
            }

            return null;
        }
    }
}
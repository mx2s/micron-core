// ReSharper disable InconsistentNaming

using System;
using System.Linq;
using Dapper;
using Micron.DL.Module.Job;

namespace Micron.DL.Model.Schedule {
    public class LastScheduledJobDate : Model {
        public int id;

        public string guid;

        public string name;

        public DateTime last_executed;

        public DateTime created_at;

        public DateTime updated_at;

        public static LastScheduledJobDate Find(int id)
            => Connection().Query<LastScheduledJobDate>(
                "SELECT * FROM last_scheduled_job_dates WHERE id = @id LIMIT 1",
                new {id}
            ).FirstOrDefault();

        public static LastScheduledJobDate FindByGuid(string guid)
            => Connection().Query<LastScheduledJobDate>(
                "SELECT * FROM last_scheduled_job_dates WHERE guid = @guid LIMIT 1",
                new {guid}
            ).FirstOrDefault();

        public static LastScheduledJobDate FindByJobName(string name)
            => Connection().Query<LastScheduledJobDate>(
                "SELECT * FROM last_scheduled_job_dates WHERE name = @name LIMIT 1",
                new {name}
            ).FirstOrDefault();

        public static LastScheduledJobDate Find(IJob job) => FindByJobName(job.Name);

        public LastScheduledJobDate Save(DateTime lastExecuted) {
            ExecuteSql(
                @"UPDATE last_scheduled_job_dates SET last_executed = @last_executed, updated_at = @updated_at 
                  WHERE id = @id",
                new {last_executed, updated_at = DateTime.Now, id}
            );
            return this;
        }

        public LastScheduledJobDate UpdateNow() {
            Save(DateTime.Now);
            return this;
        }
    }
}
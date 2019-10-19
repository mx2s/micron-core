using System;
using Micron.DL.Module.Job;
using Micron.DL.Module.Schedule.Enum;

namespace Micron.DL.Module.Schedule {
    public class ScheduledJob {
        private IJob _job;

        private SchedulePeriod _period;

        private ushort _timeAmount;

        public DateTime lastExecuted;
        
        public ScheduledJob(IJob job, SchedulePeriod period, ushort timeAmount) {
            _job = job;
            _period = period;
            _timeAmount = timeAmount;
            lastExecuted = DateTime.Now;
        }
    }
}
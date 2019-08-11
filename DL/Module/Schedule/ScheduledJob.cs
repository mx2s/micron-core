using System;
using BaseFramework.DL.Module.Job;
using BaseFramework.DL.Module.Schedule.Enum;

namespace BaseFramework.DL.Module.Schedule {
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
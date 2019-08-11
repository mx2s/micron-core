using System;

namespace BaseFramework.DL.Module.Schedule {
    public static class ScheduleUtils {
        public static DateTime GetJobNextExecutionDate(ScheduledJob job) {
            return DateTime.Now;
        }
    }
}
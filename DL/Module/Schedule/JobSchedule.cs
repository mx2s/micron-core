using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Micron.DL.Module.Schedule {
    public class JobSchedule {
        public static JobSchedule instance;

        private List<ScheduledJob> activeJobs;

        private bool _started;
        
        public JobSchedule() {
            activeJobs = new List<ScheduledJob>();
        }

        public static JobSchedule Get() {
            if (instance == null) {
                instance = new JobSchedule();
            }
            return instance;
        }

        private void StartSchedule() {
            if (_started) {
                return;
            }
            _started = true;
            
            Task.Run(() => {
                while (true) {
                    Task.Delay(1000);
                    try {
                        foreach (var job in activeJobs) {
                            
                        }
                    }
                    catch (Exception e) {
                        // TODO: log errors into schedule_errors.log
                    }
                }
            });
        }

        public void AddJob(ScheduledJob job) {
            activeJobs.Add(job);
        }
    }
}
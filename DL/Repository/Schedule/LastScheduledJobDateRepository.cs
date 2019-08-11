using BaseFramework.DL.Model.Schedule;
using BaseFramework.DL.Module.Job;

namespace BaseFramework.DL.Repository.Schedule {
    public static class LastScheduledJobDateRepository {
        public static LastScheduledJobDate Find(int id)
            => LastScheduledJobDate.Find(id);

        public static LastScheduledJobDate FindByGuid(string guid)
            => LastScheduledJobDate.FindByGuid(guid);

        public static LastScheduledJobDate FindByJobName(string name)
            => LastScheduledJobDate.FindByJobName(name);

        public static LastScheduledJobDate Find(IJob job) => FindByJobName(job.Name);
    }
}
namespace Micron.DL.Module.Job {
    public interface IJob {
        string Name { get; }
        
        void Handle();
    }
}
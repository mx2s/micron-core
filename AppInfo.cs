namespace Micron {
    public class AppInfo {
        public string GetAssemblyVersion() {    
            return GetType().Assembly.GetName().Version.ToString();
        }
    }
}
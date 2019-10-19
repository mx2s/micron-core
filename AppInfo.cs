namespace BaseFramework {
    public class AppInfo {
        public string GetAssemblyVersion() {    
            return GetType().Assembly.GetName().Version.ToString();
        }
    }
}
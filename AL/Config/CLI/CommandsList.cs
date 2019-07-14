using BaseFramework.AL.CLI.Basic;
using BaseFramework.DL.Module.CLI;

namespace BaseFramework.AL.Config.CLI {
    public static class CommandsList {
        public static ICliCommand[] Get()
            => new ICliCommand[] {
                new PrintFrameworkVersion(),
            };
    }
}
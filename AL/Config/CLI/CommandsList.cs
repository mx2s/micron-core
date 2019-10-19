using Micron.AL.CLI.Basic;
using Micron.DL.Module.CLI;

namespace Micron.AL.Config.CLI {
    public static class CommandsList {
        public static ICliCommand[] Get()
            => new ICliCommand[] {
                new PrintFrameworkVersion(),
            };
    }
}
using System.Collections.Generic;
using BaseFramework.DL.Module.CLI;

namespace BaseFramework.AL.CLI.Basic {
    public class PrintFrameworkVersion : ICliCommand {
        public string Signature { get; } = "framework-version";
        
        public List<string> StrOutput { get; set; }

        public PrintFrameworkVersion() {
            StrOutput = new List<string>();
        }
        
        public CliResult Execute() {
            StrOutput.Add("Framework version: " + AppInfo.Version);
            return new CliResult(CliExitCode.Ok, StrOutput);
        }
    }
}
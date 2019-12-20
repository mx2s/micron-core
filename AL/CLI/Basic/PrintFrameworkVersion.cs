using System.Collections.Generic;
using Micron.DL.Module.CLI;

namespace Micron.AL.CLI.Basic {
    public class PrintFrameworkVersion : ICliCommand {
        public string Signature { get; } = "framework-version";
        
        public List<string> StrOutput { get; set; }

        public PrintFrameworkVersion() {
            StrOutput = new List<string>();
        }
        
        public CliResult Execute() {
            StrOutput.Add("Micron core version: " + new AppInfo().GetAssemblyVersion());
            return new CliResult(CliExitCode.Ok, StrOutput);
        }
    }
}
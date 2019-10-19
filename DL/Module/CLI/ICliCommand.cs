using System.Collections.Generic;

namespace Micron.DL.Module.CLI {
    public interface ICliCommand {
        string Signature { get; }
        
        List<string> StrOutput { get; set; }

        CliResult Execute();
    }
}
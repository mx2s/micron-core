using System;
using System.Collections.Generic;

namespace BaseFramework.DL.Module.CLI {
    public class CliResult {
        public CliExitCode ExitCode { get; }

        public List<string> StrOutput { get; }
        
        public CliResult(CliExitCode exitCode, List<string> strOutput = null) {
            ExitCode = exitCode;
            StrOutput = strOutput ?? new List<string>();
        }

        public void PrintOutput() {
            Console.WriteLine("\nCommand output:");
            foreach (var item in StrOutput) {
                Console.WriteLine(item);
            }
            Console.WriteLine("\nExited with code: " + ExitCode);
            Console.WriteLine('\n');
            for (var i = 0; i <= 30; i++) {
                Console.Write('*');
            }
            Console.WriteLine('\n');
        }
    }
}
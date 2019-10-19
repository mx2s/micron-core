using System;

namespace Micron.DL.Module.CLI {
    public static class Cli {
        /// <summary>
        /// Starts CLI loop with specified set of commands which can be executed
        /// </summary>
        /// <param name="commands">Array of commands to be executed</param>
        public static void CliLoop(ICliCommand[] commands) {
            for (;;) {
                try {
                    Console.WriteLine("\nType command: ");
                    var nextCommand = Console.ReadLine();
                    foreach (var command in commands) {
                        if (command.Signature == nextCommand) {
                            command.StrOutput.Clear();
                            Console.WriteLine("Executing command " + nextCommand + " ...");
                            var result = command.Execute();
                            result.PrintOutput();
                        }
                    }
                    if (nextCommand == "exit") {
                        Console.WriteLine("Exiting cli loop...");
                        break;
                    }
                }
                catch (Exception e) {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
    }
}
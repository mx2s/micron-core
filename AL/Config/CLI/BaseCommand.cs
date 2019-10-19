using System;
using System.Collections.Generic;

namespace Micron.AL.Config.CLI {
    public abstract class BaseCommand {
        public abstract string Signature { get; }
        
        public List<string> StrOutput { get; set; }

        public bool Ask(string question) {
            Output(question + "[y/n]");
            var res = Console.ReadLine();
            return res == "y";
        }
        
        public void Output(string str) {
            StrOutput.Add(str);
            Console.WriteLine(str);
        }
    }
}
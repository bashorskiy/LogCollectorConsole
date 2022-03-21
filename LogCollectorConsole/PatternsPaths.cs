using System.Collections.Generic;

namespace LogCollectorConsole
{
    public static class PatternsPaths
    {
        private static readonly List<string> _patterns = new List<string>
        {
        "TXUpdater_*.log",        
        "DB\\Referent.~f*"
        };
        public static List<string> Patterns { get => _patterns; }
    }
}






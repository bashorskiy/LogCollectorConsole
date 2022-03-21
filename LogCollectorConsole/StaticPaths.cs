using System.Collections.Generic;

namespace LogCollectorConsole
{

    public static class StaticPaths
    {
        private static readonly List<string> _paths = new List<string>
        {
        "referent.ini",
        "log\\Referent\\Referent.log",
        "Referent_Setup.ini",
        "Referent0.ini"
        };

        public static List<string> Paths { get => _paths;}

    }


}




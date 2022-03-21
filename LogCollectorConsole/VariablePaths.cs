using System.Collections.Generic;

namespace LogCollectorConsole
{

    public static class VariablePaths
    {
        private static readonly List<string> _paths = new List<string>
        {
        "log\\Referent\\ref_crypto_",
        "CPCrypto.ini",
        "log\\CPCrypto\\CPCrypto.log",
        "log\\Referent\\protocol_",
        "log\\FormatCheck\\FormatCheck.log",
        "log\\Referent\\Reftransport.log",
        "DocEngineError.log",
        "dbconnection.ini",
        "DB\\dover.fdb",
        "DB\\Backup"
        };
        public static List<string> Paths { get => _paths; }
    }
}






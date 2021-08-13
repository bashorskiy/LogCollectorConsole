using System.Collections.Generic;
using System.IO;

namespace LogCollectorConsole
{
    public abstract class Collector
    {
        private List<string> _standartPaths;
        private bool ExistCheck(string path)
        {
            return Directory.Exists(path);
        }
    }

    public class RefCollector : Collector
    {
        enum Cases
        {
            Cryptography = 1,
            Transport,
            Update,
            TaxControl,
            ImportInDB,
            PostProcessing_Visualization,
            DBUpdate,
            DBBreak,
            Connection,
            CirculationError,
            Other
        }
    }

    public class DocCollector : Collector
    {
       
    }



}

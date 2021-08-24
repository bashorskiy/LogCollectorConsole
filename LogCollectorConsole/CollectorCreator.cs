using System.Collections.Generic;

namespace LogCollectorConsole
{
    public class CollectorCreator
    {
        protected Dictionary<int, List<string>> _cases; 
        protected virtual void InitializePaths()
        {

        }
        protected virtual List<string> GetValue(int key)
        {
            return new List<string>();
        }
    }
}



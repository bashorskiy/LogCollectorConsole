using System.Collections.Generic;
using System.IO;

namespace LogCollectorConsole
{
    public class CaseProcessor
    {
        public void Process(OAIKPOTaskCase taskCase)
        {
            List<string> resultPaths = new List<string>();
            string currentDirectoryPath = Directory.GetCurrentDirectory();
            if (taskCase.IsPattern)
            {
                resultPaths.AddRange(Directory.GetFiles(currentDirectoryPath, taskCase.Pattern, SearchOption.AllDirectories));
            }
            for (int i = 0; i < taskCase.Paths.Count; i++)
            {
                string path = taskCase.Paths[i];
                if (taskCase.IsLoginNeed)
                {
                    if (path.Equals(VariablePaths.Paths[0]) || path.Equals(VariablePaths.Paths[3]))
                    {
                        taskCase.Paths[i] = taskCase.Login + ".log";
                    }
                }
                if (path.Equals(VariablePaths.Paths[11]))
                {
                    resultPaths.AddRange(Directory.GetFiles(currentDirectoryPath+"\\"+path,".*",SearchOption.AllDirectories));
                }
                resultPaths.Add(currentDirectoryPath+taskCase.Paths[i]);
            }
            taskCase.Paths.AddRange(resultPaths);
        }

        private void ss()
        {

        }
    }
}




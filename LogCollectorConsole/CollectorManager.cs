using System;
using System.IO;

namespace LogCollectorConsole
{
    public class CollectorManager
    {
        private bool _isRef;
        private bool _isExist = true;
        private int _casesCount = 4;

        public CollectorManager()
        {
            CheckingProgram();
            DistributeObjects();
        }

        private void CheckingProgram()
        {
            string refPath = Path.Combine(Directory.GetCurrentDirectory(), "Referent.exe");
            string docPath = Path.Combine(Directory.GetCurrentDirectory(), "Client\\DoclinerSingle.exe");
            if (File.Exists(refPath))
            {
                Console.WriteLine("Найден Референт");
                _isRef = true;
            }
            else if (File.Exists(docPath))
            {
                Console.WriteLine("Найден Доклайнер");
                _isRef = false;
            }
            else
            {
                _isExist = false;
            }
        }

        private void DistributeObjects()
        {
            if (!_isExist)
            {
                Printer.Errors.IncorrectPath();
                Console.ReadLine();
            }
            else if (_isRef)
            {                
                while (true)
                {
                    RefCollectorCreator creator = new RefCollectorCreator(key);
                    Printer.Menu.PrintRefMenu();
                    bool isChoice = int.TryParse(Console.ReadLine(), out int key);
                    if (isChoice && key > 0 && key <_casesCount)
                    {                       
                        
                        break;
                    }
                    else
                    {
                        Printer.Errors.IncorrectChoice();
                    }
                }
            }
            else if (!_isRef)
            {

            }
        }
    }


   
}

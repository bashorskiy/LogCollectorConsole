using System;
using System.IO;

namespace LogCollectorConsole
{
    public class CollectorManager
    {
        private bool _isRef;
        private bool _isExist = true;
        private const int _casesCount = 5;

        public CollectorManager()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
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
                    Printer.Menu.PrintRefMenu();
                    bool isChoice = int.TryParse(Console.ReadLine(), out int key);
                    if (isChoice && key > 0 && key <_casesCount)
                    {
                        new RefCollectorCreator(key);
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
                Printer.Warnings.Sorry();
                Console.ReadKey();
            }
        }
    }
  
}

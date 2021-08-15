using System;

namespace LogCollectorConsole
{
    public class Printer
    {
        public class Menu
        {
            public static void PrintRefMenu()
            {
                Console.WriteLine("\n\t\t Логи для Референта \n" +
                    "Пожалуйста, выберите случай, для которого вам необходимо собрать логи\n" +
                    "1.logupdate\n" +
                    "2.logreport\n" +
                    "3.logimport\n" +
                    "4.logother\n");
            }
        }

        public class Errors
        {
            public static void IncorrectChoice()
            {
                Console.WriteLine("Такой пункт не предусмотрен.");
            }

            public static void NotEnoughSpace()
            {
                Console.WriteLine("Недостаточно места на данном диске для копирования!");
            }

            public static void IncorrectPath()
            {
                Console.WriteLine("Не найдена программа! \n" +
                       "Пожалуйста, переместите LogCollector в папку с Референтом (в ней должен быть файл Referent.exe) \n" +
                       "Или в корневую папку Доклайнера (в ней должны быть папки Client, DB и Server) \n" +
                       "И перезапустите LogCollector");
            }
        }
        public class Warnings
        {
            public static void MissFiles()
            {
                Console.WriteLine("Предупреждение! \n " +
                    "Не найдены некоторые файлы, необходимые для отдела аналитики! \n " +
                    "Пожалуйста, соберите их вручную или укажите это в описании инцидента.");
            }

        }

        public class Info
        {
            public static void CheckSpace()
            {
                Console.WriteLine("Проверяем наличие свободного места для копирования...");
            }
            public static void StartingCopy()
            {
                Console.WriteLine("Начинаем процесс копирования. Логи будут скопированы в папку _IncidentLogs");
            }
            public static void StartingArchive()
            {
                Console.WriteLine("Начинаем процесс архивации. Логи будут заархивированы в файл _IncidentLogs.zip");
            }
            public static void CopyFinish(string destination)
            {
                Console.WriteLine($"Завершено копирование файлов в {destination}");
            }
            public static void ArchiveFinish (string source, string destination)
            {
                Console.WriteLine($"Папка {source} успешно заархивирована в файл {destination}");
            }
        }

        public class Question
        {
            public static void WantToArchive()
            {
                Console.WriteLine("Вы хотите заархивировать полученные логи?\n" +
                    "1. Да \n" +
                    "2. Нет");
            }
        }


    }
}

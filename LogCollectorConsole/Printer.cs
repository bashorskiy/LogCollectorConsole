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
                    "1. Криптография\n" +
                    "2. Транспорт писем\n" +
                    "3. Обработка писем/Визуализация ЭДО\n" +
                    "4. Ошибки ЭДО\n" +
                    "5. Обновление\n" +
                    "6. Выходной контроль\n" +
                    "7. Импорт файлов в базу данных\n" +
                    "8. Подключение по сети\n" +
                    "9. Обновление базы данных\n" +
                    "10. Ошибка базы данных\n" +
                    "11. Остальные случаи\n");
            }
        }

        public class Errors
        {
            public static void IncorrectChoice()
            {
                Console.WriteLine("Такой пункт не предусмотрен.");
            }         
            public static void IncorrectPath()
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("Не найдена программа! \n" +
                       "Пожалуйста, переместите LogCollector в папку с Референтом (в ней должен быть файл Referent.exe) \n" +
                       "Или в корневую папку Доклайнера (в ней должны быть папки Client, DB и Server) \n" +
                       "И перезапустите LogCollector");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            public static void MissAllFiles()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n \n \t \t Не найдено ни одного файла! \n \n ");
                Console.ResetColor();
                Console.WriteLine("Пожалуйста, соберите их вручную или переместите LogCollector в правильную директорию");
            }

            public static void IncorrectLogin()
            {
                Console.WriteLine("Файл с таким логином не найден! Хотите продолжить или ввести логин заново?\n" +
                    "1. Ввести логин заново\n" +
                    "2. Пропустить этот файл");
            }
        }
        public class Warnings
        {
            public static void MissFiles()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n \n \t \t Предупреждение \n \n " +
                    "Не найдены некоторые файлы, необходимые для отдела аналитики! \n " +
                    "Пожалуйста, соберите их вручную или укажите это в описании инцидента.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            public static void Sorry()
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n \n \t \t Предупреждение \n \n " +
                    "К сожалению, данный функционал ещё не дописан. Ожидайте обновлений");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public class Info
        {
            public static void EnterLogin()
            {
                Console.WriteLine("Для данного случая необходимы логи с указанием логина клиента. Пожалуйста, введите логин до знака собаки (@)");
            }           
            public static void StartingCopy()
            {
                Console.WriteLine("\n Начинаем процесс копирования. Логи будут скопированы в папку _IncidentLogs");
            }
            public static void StartingDelete()
            {
                Console.WriteLine("\n Начинаем процесс удаления. Архив, если был создан, останется на месте.");
            }
            public static void StartingArchive()
            {
                Console.WriteLine("\n Начинаем процесс архивации. Логи будут заархивированы в файл *_IncidentLogs.zip");
            }
            public static void CopyFinish(string destination)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n \n Завершено копирование файлов в {destination} \n \n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            public static void ArchiveFinish(string source, string destination)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Папка {source} успешно \n заархивирована в файл {destination}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            public static void DeleteFinish(string source)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Папка {source} успешно удалена!");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            public static void ProgramFinish()
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Работа программы завершена. Нажмите любую клавишу для закрытия окна.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            public static void Credits()
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\n \n Если у вас есть предложения по доработке или добавлению нового функционала, пожалуйста,\n напишите письмо на");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" BikinMV@taxcom.ru ");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("я обязательно вам отвечу");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Разработано специально для компании Taxcom");
            }

            public static void ErrorEscalating()
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Возникло исключение! Пожалуйста, направьте скриншот с ошибкой и описанием действий на");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(" BikinMV@taxcom.ru ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("если хотите, чтобы это было исправлено в следующем обновлении");
            }
        }

        public class Questions
        {
            public static void WantToArchive()
            {
                Console.WriteLine("\n Вы хотите заархивировать полученные логи?\n" +
                    "1. Да \n" +
                    "2. Нет");
            }
            public static void WantToDelete()
            {
                Console.WriteLine("Вы хотите удалить исходную папку с собранными логами? (архив, если был создан, останется на месте)\n" +
                    "1. Да \n" +
                    "2. Нет");
            }
        }
    }
}

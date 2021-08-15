using System;

namespace LogCollectorConsole
{
    public class Printer
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
        public static void ErrorPrintRefMenu()
        {
            Console.WriteLine("Такой пункт не предусмотрен.");
        }

        public static void ErrorNotEnoughSpace()
        {
            Console.WriteLine("Недостаточно места на данном диске для копирования!");
        }
    }
}

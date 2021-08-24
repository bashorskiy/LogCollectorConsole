
namespace LogCollectorConsole
{
	class Program
	{
		static void Main()
		{
			try
			{
                new CollectorManager();
                Printer.Info.ProgramFinish();
                System.Console.ReadKey();
                Printer.Info.Credits();
			}
			catch (System.Exception e)
			{
				System.Console.WriteLine(e.Message);
				System.Console.WriteLine(e.StackTrace);
				Printer.Info.ErrorEscalating();
			}
			System.Console.ReadKey();
		}
	}
}

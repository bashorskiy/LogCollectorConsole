
namespace LogCollectorConsole
{
	#region Ref

	/*
	 

    Обновление базы данных 

    Поломка базы данных     

	 */	
	
	/*DBUpdate
	+ Referent.log; (C:\Dipost\log\Referent) #
	+ Referent0.ini; (C:\Dipost) #
	+ referent.ini; (C:\Dipost) #
	+ Referent_Setup.ini; (C:\Dipost)
	+ dover.fdb; (C:\Dipost\db)
	+ DB\Backup. (C:\Dipost\db\backup)    
	*/

	/*DBBreak
	+ Referent.log; (C:\Dipost\log\Referent) #
	+ Referent0.ini; (C:\Dipost) #
	+ referent.ini; (C:\Dipost) #
	+ Referent_Setup.ini; (C:\Dipost)
	+ DB\Referent.~fN; (C:\Dipost\db)
	+ DB\Backup. (C:\Dipost\db\backup)  
	*/

	

	

	

	#endregion

	#region DoclinerSingle

	/*LaunchUpdateError
	+C:\Taxcom\Docliner Single\Client\log\ReferentNet.log 
	+C:\Taxcom\Docliner Single\Server\RefNetUpdate\log\RefNetUpdate.log
	+C:\Taxcom\Docliner Single\Client\log\Launcher.log
	+C:\Taxcom\Docliner Single\Server\log\NativeUpdater\NativeUpdater.log
	+C:\Taxcom\Docliner Single\Server\log\RefNetService\RefNetService.log 
	*/

	/*SendRecieveError 
	+ C:\Taxcom\Docliner Single\Client\log\ReferentNet.log 
	+ C:\Taxcom\Docliner Single\Client\log\TISLoader\TISLoader.log
	+ C:\Taxcom\Docliner Single\Server\log\CPCrypto\CPCrypto.log
	+ C:\Taxcom\Docliner Single\Server\log\MailProcessor\MailProcessor.log
	+ C:\Taxcom\Docliner Single\Server\log\UnifiedFormat\UnifiedFormat.log 
	*/

	/*Import
	+ C:\Taxcom\Docliner Single\Client\log\ReferentNet.log 
	+ C:\Taxcom\Docliner Single\Client\log\FormatCheck\FormatCheck.log     
	*/

	/*DocCheck
	+C:\Taxcom\Docliner\Server\log\FormatCheck\FormatCheck.log
	+ C:\Taxcom\Docliner\Client\log\adm\Docliner.log
	+ C:\Taxcom\Docliner\Client\log\Пользователь \FormatCheck\FormatCheck.log
	+ C:\Taxcom\Docliner\Server\log\CPCrypto\CPCrypto.log 
	*/

	/*Other
	+ Вся папка C:\Taxcom\Docliner Single\Client\log
	+ Вся папка C:\Taxcom\Docliner Single\Server\log 
	*/

	#endregion
	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				new CollectorManager();
				Printer.Info.ProgramFinish();
			}
			catch (System.Exception e)
			{
				System.Console.WriteLine(e.Message);
				System.Console.WriteLine(e.StackTrace);
			}
			System.Console.ReadKey();
		}
	}
}

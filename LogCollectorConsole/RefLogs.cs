using LogCollectorConsole.RefResources;
using System.Globalization;

namespace LogCollectorConsole
{
    public class RefLogs : LogFilesPaths
    {
        public override int GetChildrenCount()
        {
            return base.GetChildrenCount();
        }
    }
    public class LogUpdateError : RefLogs
    {
        public LogUpdateError()
        {
            _resSet = UpdateError.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            Intialize();
        }
    }

    public class LogReportControl : RefLogs
    {
        public LogReportControl()
        {
            _resSet = ReportControl.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            Intialize();
        }
    }

    public class LogImportInDB : RefLogs
    {
        public LogImportInDB()
        {
            _resSet = ImportInDB.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            Intialize();
        }
    }

    public class LogOther : RefLogs
    {
        public LogOther()
        {
            _resSet = Other.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            Intialize();
        }
    }



}

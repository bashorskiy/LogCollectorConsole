namespace LogCollectorConsole
{
    public class RefCollectorCreator
    {
        public RefCollectorCreator(int key)
        {
            LogFilesPaths paths = null;
            switch (key)
            {
                case 1:
                    {
                        paths = new LogUpdateError();                        
                        break;
                    }
                case 2:
                    {
                        paths = new LogReportControl();
                        break;
                    }
                case 3:
                    {
                        paths = new LogImportInDB();
                        break;
                    }
                case 4:
                    {
                        paths = new LogOther();
                        break;
                    }                   
            }
            RefCollector refCollector = new RefCollector(paths);
        }
    }


}

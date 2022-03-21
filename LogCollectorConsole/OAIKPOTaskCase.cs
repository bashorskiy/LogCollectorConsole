using System.Collections.Generic;

namespace LogCollectorConsole
{
    public class OAIKPOTaskCase
    {
        private List<string> _paths;      
        private int _caseID;
        private bool _isLoginNeed;
        private bool _isPattern;
        private string _login;
        private string _pattern;




        public int CaseID { get => _caseID; set => _caseID = value; }
        public List<string> Paths { get => _paths; set => _paths = value; }        
        public string Login { get => _login; set => _login = value; }
        public string Pattern { get => _pattern; set => _pattern = value; }
        public bool IsPattern { get => _isPattern; set => _isPattern = value; }
        public bool IsLoginNeed { get => _isLoginNeed; set => _isLoginNeed = value; }
    }
}




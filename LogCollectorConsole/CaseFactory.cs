using System.Collections.Generic;

namespace LogCollectorConsole
{
    public class CaseFactory
    {
        private OAIKPOTaskCase _newcase;
        public OAIKPOTaskCase CreateCase(CaseDTO dto)
        {
            _newcase = new OAIKPOTaskCase
            {
                Login = dto.Login,
                CaseID = dto.CaseID,
                IsPattern = false,
                IsLoginNeed = false
            };
            _newcase.Paths.AddRange(StaticPaths.Paths);
            ResolveTaskProperties(dto);
            return _newcase;
        }

        private void ResolveTaskProperties(CaseDTO dto)
        {
            List<string> result = new List<string>();
            switch (dto.CaseID)
            {
                case 1: //Криптография
                    result.Add(VariablePaths.Paths[0]);
                    result.Add(VariablePaths.Paths[1]);
                    result.Add(VariablePaths.Paths[2]);
                    _newcase.IsLoginNeed = true;
                    break;
                case 2: //Транспорт писем
                    result.Add(VariablePaths.Paths[3]);
                    result.Add(VariablePaths.Paths[4]);
                    result.Add(VariablePaths.Paths[5]);
                    _newcase.IsLoginNeed = true;
                    break;
                case 3: //Обработка писем/Визуализация ЭДО
                    result.Add(VariablePaths.Paths[0]);
                    result.Add(VariablePaths.Paths[4]);
                    result.Add(VariablePaths.Paths[1]);
                    result.Add(VariablePaths.Paths[6]);           
                    _newcase.IsLoginNeed = true;
                    break;
                case 4: //Ошибки ЭДО
                    result.Add(VariablePaths.Paths[0]);
                    result.Add(VariablePaths.Paths[1]);
                    _newcase.IsLoginNeed = true;
                    break;
                case 5: //Обновление
                    _newcase.Pattern = PatternsPaths.Patterns[0]; ;
                    _newcase.IsPattern = true;
                    break;
                case 6: //Выходной контроль
                    result.Add(VariablePaths.Paths[4]);
                    break;
                case 7: //Импорт файлов в базу данных                    
                    break;
                case 8: //Подключение по сети
                    result.Add(VariablePaths.Paths[7]);
                    result.Add(VariablePaths.Paths[5]);
                    result.Add(VariablePaths.Paths[0]);
                    result.Add(VariablePaths.Paths[3]);
                    _newcase.IsLoginNeed = true;
                    break;
                case 9: //Обновление базы данных 
                    _newcase.Pattern = PatternsPaths.Patterns[1];
                    result.Add(VariablePaths.Paths[8]);
                    result.Add(VariablePaths.Paths[9]);
                    _newcase.IsPattern = true;
                    break;
                case 10: //Ошибка базы данных
                    _newcase.Pattern = PatternsPaths.Patterns[1];
                    result.Add(VariablePaths.Paths[9]);
                    _newcase.IsPattern = true;
                    break;
                default: // Остальные случаи
                    break;
            }
            _newcase.Paths.AddRange(result);
        }
    }
}




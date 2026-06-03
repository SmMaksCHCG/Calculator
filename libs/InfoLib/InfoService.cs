using System.Collections.Generic;

namespace Calculator.InfoLib;

public class InfoService
{
    public IEnumerable<string> GetDevelopers() => new[] { "Student: SmMaksCHCG", "Instructor: Sergey" };
}

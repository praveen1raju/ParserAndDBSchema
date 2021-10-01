using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Models
{
    public interface iParser
    {
        string parseInput(string inputToBeParsed, string tokenBegin, string tokenEnd, Dictionary<string, string> TokensAndReplacements);
    }
}

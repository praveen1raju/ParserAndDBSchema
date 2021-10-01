using System;
using System.Collections.Generic;
namespace EmailParserClassLibrary
{
    public interface iParser
    {
        string parseInput(string inputToBeParsed, string tokenBegin, string tokenEnd, Dictionary<string, string> TokensAndReplacements);
    }
}

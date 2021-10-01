using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    #region ParserTwo
    public class ParserTwo : iParser
    {
        public string parseInput(string inputToBeParsed, string tokenBegin, string tokenEnd, Dictionary<string, string> TokensAndReplacements)
        {
            StringBuilder Output = new StringBuilder();
            int inputStringLength = inputToBeParsed.Length;
            int CurrStartIndex = 0, CurrEndIndex = 0, LastEndIndex;
            string CurrentToken;
            while (CurrStartIndex < inputStringLength && CurrStartIndex > -1)
            {
                LastEndIndex = CurrEndIndex;
                if (LastEndIndex == 0)
                {
                    CurrStartIndex = inputToBeParsed.IndexOf(tokenBegin, 0, StringComparison.InvariantCultureIgnoreCase);
                }
                else
                {
                    CurrStartIndex = inputToBeParsed.IndexOf(tokenBegin, LastEndIndex + tokenEnd.Length, StringComparison.InvariantCultureIgnoreCase);
                }
                if (CurrStartIndex > -1)
                {
                    //found starting token 
                    CurrEndIndex = inputToBeParsed.IndexOf(tokenEnd, CurrStartIndex + tokenBegin.Length, StringComparison.InvariantCultureIgnoreCase);
                    if (CurrEndIndex > -1)
                    {
                        CurrentToken = inputToBeParsed.Substring(CurrStartIndex + tokenBegin.Length, CurrEndIndex - (CurrStartIndex + tokenBegin.Length));
                        if (LastEndIndex == 0)//this is the first time
                        {
                            Output.Append(inputToBeParsed.Substring(0, CurrStartIndex));
                            Output.Append(TokensAndReplacements[CurrentToken] + " " + TokensAndReplacements[CurrentToken]);
                        }
                        else
                        {
                            Output.Append(inputToBeParsed.Substring(LastEndIndex + tokenEnd.Length, CurrStartIndex - (LastEndIndex + tokenEnd.Length)));
                            Output.Append(TokensAndReplacements[CurrentToken] + " " + TokensAndReplacements[CurrentToken]);
                        }
                    }
                }
                else
                {
                    //reached the end
                    //append what is left 
                    if (LastEndIndex == 0)
                    {
                        Output.Append(inputToBeParsed.Substring(0));
                    }
                    else
                    {
                        Output.Append(inputToBeParsed.Substring(LastEndIndex + tokenEnd.Length));
                    }
                }
            }

            return Output.ToString();
        }
    }
    #endregion ParserTwo
}

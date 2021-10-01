using System;
using System.Collections.Generic;
using System.Text;
// test case
// space & time complexity 

namespace EmailTokenParser
{
    
    
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        //iParser ip = new ParserTwo();
    //        //string input = "hello {{tknname}} how are you this lovely {{tkntimeofday}} ? ";
    //        //input = "hello {{{tknname}} how are you this lovely {{{tkntimeofday}} ? ";
    //        //input = "how are you this lovely  ? {{{tkntimeofday}} ";
    //        //input = "Hello {{{tknSalutation}}.{{{tknname}}! how are you this lovely {{{tkntimeofday}} ? we hope to earn your {{{tknbusinesstype}} business soon!";
    //        //Dictionary<string, string> tokensandreplacements = new Dictionary<string, string>
    //        //{
    //        //    { "tknname", "Praveen" },
    //        //    { "tkntimeofday", "Evening" },
    //        //    { "tknbusinesstype", "Plumbing" },
    //        //    { "tknSalutation", "Mr" }
    //        //};
    //        //var res = ip.parseInput(input, "{{{", "}}", tokensandreplacements);
    //        //Console.WriteLine(res);
    //        //Console.Read();
    //    }
    //}

    #region ParserOne
    public class ParserOne : iParser
    {
        public string parseInput(string inputToBeParsed, string tokenBegin, string tokenEnd, Dictionary<string, string> TokensAndReplacements)
        {
            //use stringbuilder 
            //tdd
            //checkin to git
            StringBuilder Output = new StringBuilder();
            int inputStringLength = inputToBeParsed.Length;
            int CurrStartIndex = 0, CurrEndIndex = 0, LastEndIndex;
            string CurrentToken = "";
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
                            Output.Append(TokensAndReplacements[CurrentToken]);
                        }
                        else
                        {
                            Output.Append(inputToBeParsed.Substring(LastEndIndex + tokenEnd.Length, CurrStartIndex - (LastEndIndex + tokenEnd.Length)));
                            Output.Append(TokensAndReplacements[CurrentToken]);
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
    #endregion ParserOne

    #region ParserTwo
    public class ParserTwo : iParser
    {
        public string parseInput(string inputToBeParsed, string tokenBegin, string tokenEnd, Dictionary<string, string> TokensAndReplacements)
        {
            //use stringbuilder 
            //tdd
            //checkin to git
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

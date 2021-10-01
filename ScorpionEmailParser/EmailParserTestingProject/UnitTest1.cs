using Microsoft.VisualStudio.TestTools.UnitTesting;
using EPCLib=EmailParserClassLibrary;
using System.Collections.Generic;
using System;
using EmailParserClassLibrary;

namespace EmailParserTestingProject
{
    [TestClass]
    public class UnitTestForEmailParser
    {
        [TestMethod]
        public void TestMethodNoTokensInInputParserOne()
        {
            iParser ip = new ParserTwo();
            string input = "Hello business soon!";
            Dictionary<string, string> tokensandreplacements = new Dictionary<string, string>
            {
                { "tknname", "Praveen" },
                { "tkntimeofday", "Evening" },
                { "tknbusinesstype", "Plumbing" },
                { "tknSalutation", "Mr" }
            };           
            var res = ip.parseInput(input, "{{{", "}}", tokensandreplacements);
            Assert.AreEqual(res, "Hello business soon!");            
        }

        [TestMethod]
        public void TestMethodEmptyStringParserOne()
        {
            iParser ip = new ParserTwo();
            string input =  "";
            Dictionary<string, string> tokensandreplacements = new Dictionary<string, string>
            {
                { "tknname", "Praveen" },
                { "tkntimeofday", "Evening" },
                { "tknbusinesstype", "Plumbing" },
                { "tknSalutation", "Mr" }
            };
            var res = ip.parseInput(input, "{{{", "}}", tokensandreplacements);
            Assert.AreEqual(res, "");
        }

        [TestMethod]
        public void TestMethodSpaceBeforeTokenSPaceAfterTokenParserOne()
        {            
            iParser ip = new ParserOne();
            string input = "Hello {{{tknSalutation}}.{{{tknname}}! how are you this lovely {{{tkntimeofday}} ? we hope to earn your {{{tknbusinesstype}} business soon!";           
            Dictionary<string, string> tokensandreplacements = new Dictionary<string, string>
            {
                { "tknname", "Praveen" },
                { "tkntimeofday", "Evening" },
                { "tknbusinesstype", "Plumbing" },
                { "tknSalutation", "Mr" }
            };
            var res = ip.parseInput(input, "{{{", "}}", tokensandreplacements);
            Assert.AreEqual(res, "Hello Mr.Praveen! how are you this lovely Evening ? we hope to earn your Plumbing business soon!");
        }

        [TestMethod]
        public void TestMethodSpaceBeforeTokenSPaceAfterTokenParserTwo()
        {            
            iParser ip = new ParserTwo();
            string input = "Hello {{{tknSalutation}}.{{{tknname}}! how are you this lovely {{{tkntimeofday}} ? we hope to earn your {{{tknbusinesstype}} business soon!";
            Dictionary<string, string> tokensandreplacements = new Dictionary<string, string>
            {
                { "tknname", "Praveen" },
                { "tkntimeofday", "Evening" },
                { "tknbusinesstype", "Plumbing" },
                { "tknSalutation", "Mr" }
            };
            var res = ip.parseInput(input, "{{{", "}}", tokensandreplacements);
            Assert.AreEqual(res, "Hello Mr Mr.Praveen Praveen! how are you this lovely Evening Evening ? we hope to earn your Plumbing Plumbing business soon!");
        }


    }
}

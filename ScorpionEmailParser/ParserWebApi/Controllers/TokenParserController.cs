using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ParserWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenParserController : ControllerBase
    {        
        private readonly iParser _iParser;
        public TokenParserController(iParser iparser)
        {
            _iParser = iparser;
        }

        [HttpGet]
        [AllowAnonymous]
        public  string GetEmailContent()
        {           
            string input = "Hello {{{tknSalutation}} {{{tknname}}, good {{{tkntimeofday}}! Hope to do {{{tknbusinesstype}} business with you soon!";
            Dictionary<string, string> tokensandreplacements = new Dictionary<string, string>
            {
                { "tknname", "Praveen" },
                { "tkntimeofday", "Evening" },
                { "tknbusinesstype", "Plumbing" },
                { "tknSalutation", "Mr" }
            };
            var res = _iParser.parseInput(input, "{{{", "}}", tokensandreplacements);
            return res;
        }
    }
}

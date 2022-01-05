using System;
using System.Collections.Generic;
using System.Reflection;
using CommandLine;
using CommandLine.Text;
using Microsoft.Extensions.Configuration;

namespace Golumn.Core.Domain
{
    public class GlmOptions
    {
        [Option('s', "sync", HelpText = "Sync")]
        public string[] Sync { get; set; }

        [Option('f', "first", HelpText = "Lowest/start Work Item")]
        public int? FirstWorkItemId { get; set; }

        [Option('l', "highest", HelpText = "Highest/end work item")]
        public int? LastWorkItem { get; set; }

        
        private IConfiguration _config { get; set; }

        public GlmOptions()
        {
        }
    }
}
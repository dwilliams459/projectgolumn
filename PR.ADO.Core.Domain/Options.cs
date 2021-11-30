using System;
using System.Collections.Generic;
using System.Reflection;
using CommandLine;
using CommandLine.Text;
using Microsoft.Extensions.Configuration;

namespace PR.Ado.Core.Domain
{
    public class Options
    {
        [Option('r', "pr", HelpText = "Show active pull requests")]
        public bool PullRequest { get; set; }

        [Option('s', "search", HelpText = "Provide search criteria")]
        public string SearchText { get; set; }

        [Option("id", HelpText = "Display details of a single user story")]
        public string OneUserStory { get; set; }

        [Option('a', "all", HelpText = "All user stories that were ever assigned to user.")]
        public bool All { get; set; }

        [Option('b', "bugs", HelpText = "List Only Bugs")]
        public bool Bugs { get; set; }

        [Option('u', "userstory", HelpText = "List only user stories")]
        public bool UserStories { get; set; }

        [Option('p', "parent", HelpText = "Include parent titles.  Imapcts performance.")]
        public bool Parent { get; set; }

        [Option('i', "iteration", HelpText = "Filter by iteration with +/- or by search term. Valid iteration index values -5, -4, -3, -2, -1, 0, +1, +2, +3, +4, +5")]
        public string Iteration { get; set; }

        [Option('c', "csv", HelpText = "Display results as a comma delimited list.  Useful for time report generation.")]
        public bool CSV { get; set; }

        [Option(longName: "out", HelpText = "(not implemented) '-out filename' Print results to a file")]
        public bool Outfile { get; set; }

        [Option('e', "events", HelpText = "List database events.")]
        public bool ListEvents { get; set; }


        [Option('u', "pruser", HelpText = "PR user to run and display filters for.")]
        public string PrUsername { get; set; }

        [Option(longName: "cgiuser", HelpText = "CGI username")]
        public string CgiUsername { get; set; }

        // public string SearchText()
        // {
        //     if (SearchWords == null || SearchWords.Count == 0 )
        //     {
        //         return string.Empty;
        //     }

        //     return string.Join(" ", SearchWords);
        // }
        
        private IConfiguration _config { get; set; }

        public Options()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json").Build();

            if (string.IsNullOrWhiteSpace(PrUsername))
            {
                PrUsername = _config.GetValue<string>("defaultPrUsername", "");
            }

            if (string.IsNullOrWhiteSpace(CgiUsername))
            {
                CgiUsername = _config.GetValue<string>("defaultCgiUsername", "");
            }
        }
    }
}
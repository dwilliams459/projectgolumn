using System;
using System.Collections.Generic;
using System.Reflection;
using CommandLine;
using CommandLine.Text;

namespace PR.Ado.Core.Domain
{
    public class Options
    {
        [Option('r', "pr", HelpText = "Show active pull requests")]
        public bool PullRequest { get; set; }

        [Option('s', "search")]
        public IEnumerable<string> SearchWords { get; set; }

        [Option('o', "One user story")]
        public string OneUserStory { get; set; }

        public bool Repeat { get; set; } = true;

        [Option('a', "all")]
        public bool All { get; set; }

        [Option('b', "bugs", HelpText = "List Only Bugs")]
        public bool Bugs { get; set; }

        [Option('u', "userstory", HelpText = "List Only User Stories")]
        public bool UserStories { get; set; }

        [Option('p', "parent", HelpText = "Show Parent titles")]
        public bool Parent { get; set; }

        [Option('i', "iteration", HelpText = "Filter by iteration")]
        public string Iteration { get; set; }

        public string SearchText() 
        {
            return string.Join(" ", SearchWords);
        }
    }
}
using System.Collections.Generic;

namespace RockPaperScissorsGame
{
    public static class ApplicationValues
    {
        public const string OPT_ROCK = "rock";
        public const string OPT_PAPER = "paper";
        public const string OPT_SCISSORS = "scissors";
        public const string OPT_SPOCK = "spock";
        public const string OPT_LIZARD = "lizard";
        public const string RESULT_WIN = "win";
        public const string RESULT_LOSE = "lose";
        public const string RESULT_DRAW = "draw";
        public static readonly List<string> validOptions = new List<string>{ OPT_ROCK, OPT_PAPER, OPT_SCISSORS, OPT_SPOCK, OPT_LIZARD };
        //Define as regras de qual opção ganha, perde ou empata com a outra
        public static readonly Dictionary<string, Dictionary<string, string>> rules = new Dictionary<string, Dictionary<string, string>>{
            {OPT_ROCK, new Dictionary<string, string>{
                { OPT_ROCK, RESULT_DRAW},
                { OPT_PAPER, RESULT_LOSE},
                { OPT_SCISSORS, RESULT_WIN},
                { OPT_SPOCK, RESULT_LOSE},
                { OPT_LIZARD, RESULT_WIN},
            }},
            {OPT_PAPER, new Dictionary<string, string>{
                { OPT_ROCK, RESULT_WIN},
                { OPT_PAPER, RESULT_DRAW},
                { OPT_SCISSORS, RESULT_LOSE},
                { OPT_SPOCK, RESULT_WIN},
                { OPT_LIZARD, RESULT_LOSE},
            }},
            {OPT_SCISSORS, new Dictionary<string, string>{
                { OPT_ROCK, RESULT_LOSE},
                { OPT_PAPER, RESULT_WIN},
                { OPT_SCISSORS, RESULT_DRAW},
                { OPT_SPOCK, RESULT_LOSE},
                { OPT_LIZARD, RESULT_WIN},
            }},
            {OPT_SPOCK, new Dictionary<string, string>{
                { OPT_ROCK, RESULT_WIN},
                { OPT_PAPER, RESULT_LOSE},
                { OPT_SCISSORS, RESULT_WIN},
                { OPT_SPOCK, RESULT_DRAW},
                { OPT_LIZARD, RESULT_LOSE},
            }},
            {OPT_LIZARD, new Dictionary<string, string>{
                { OPT_ROCK, RESULT_LOSE},
                { OPT_PAPER, RESULT_WIN},
                { OPT_SCISSORS, RESULT_LOSE},
                { OPT_SPOCK, RESULT_WIN},
                { OPT_LIZARD, RESULT_DRAW},
            }},
        };
    }
}

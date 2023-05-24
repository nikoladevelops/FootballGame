using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace FootballGame
{
    public class Game
    {
        public Team FirstTeam { get; private set; }
        public Team SecondTeam { get; private set; }
        public Referee Referee { get; private set; }
        public Referee AssistantRefereeOne { get; private set; }
        public Referee AssistantRefereeTwo { get; private set; }
        public List<Goal> Goals  { get; private set; }
        public int FirstTeamScore { get; private set; }
        public int SecondTeamScore { get; private set; }

        public Game(Team firstTeam, Team secondTeam, Referee referee, Referee assistantRefereeOne, Referee assistantRefereeTwo)
        {
            var firstTeamPlayerCount = firstTeam.PlayersCount;
            var secondTeamPlayerCount = secondTeam.PlayersCount;

            if (IsGameValid(firstTeamPlayerCount, secondTeamPlayerCount) == false)
            {
                throw new ArgumentException("For a game, both teams need to consist of 11 players only.");
            }

            FirstTeam = firstTeam;
            SecondTeam = secondTeam;
            Referee = referee;
            AssistantRefereeOne = assistantRefereeOne;
            AssistantRefereeTwo = assistantRefereeTwo;
            Goals = new List<Goal>();
            FirstTeamScore = 0;
            SecondTeamScore = 0;
        }

        private bool IsGameValid(int firstTeamPlayerCount, int secondTeamPlayerCount) => firstTeamPlayerCount == 11 && secondTeamPlayerCount == 11;

        public void ScoreGoal(FootballPlayer player, int minute) 
        {
            if (FirstTeam.Players.Contains(player))
            {
                FirstTeamScore++;
            }
            else if (SecondTeam.Players.Contains(player))
            {
                SecondTeamScore++;
            }
            else 
            {
                throw new ArgumentException("Error. This player is NOT in either team.");
            }

            Goals.Add(new Goal(player, minute));
        }
        public string GetGameResult() 
        {
            return $"First team scored {FirstTeamScore} goals. Second team scored {SecondTeamScore}";
        }
        public string GetWinner() 
        {
            if (FirstTeamScore == SecondTeamScore) 
            {
                return "No winner. It's a DRAW!";
            }

            string winningTeam = "";
            if (FirstTeamScore > SecondTeamScore)
            {
                winningTeam = "First team";
            }
            else if (SecondTeamScore > FirstTeamScore)
            {
                winningTeam = "Second team";
            }
            return $"{winningTeam} wins the game!";
        }

        public string EndGame() 
        {
            var sb = new StringBuilder();
            sb.AppendLine(GetWinner());
            sb.AppendLine(GetGameResult());
            sb.AppendLine("Goals: ");
            foreach (var goal in Goals)
            {
                sb.AppendLine($"Goal by {goal.PlayerThatScored.Name}, scored at minute {goal.MinuteScored}");
            }

            return sb.ToString();
        }
    }
}

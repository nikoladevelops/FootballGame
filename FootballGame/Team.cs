namespace FootballGame
{
    public class Team
    {
        public Coach Coach { get; private set; }
        public IEnumerable<FootballPlayer> Players { get; private set; }
        public int PlayersCount { get; private set; }

        public Team(Coach coach, IEnumerable<FootballPlayer> players)
        {
            var countOfPlayers = players.Count();
            if (IsTeamValid(countOfPlayers) == false)
            {
                throw new ArgumentException("A team can consist only of 11 to 22 players max");
            }
            PlayersCount = countOfPlayers;
            Coach = coach;
            Players = players;
        }

        public double AverageAge {  // double, because we might round differently
            get
            {
                return Players.Average(x => x.Age);
            }
        }

        private bool IsTeamValid(int countOfPlayers) => countOfPlayers >= 11 && countOfPlayers <= 22;
    }
}

namespace FootballGame
{
    public class Goal
    {
        public FootballPlayer PlayerThatScored { get; private set; }
        public int MinuteScored { get; private set; }

        public Goal(FootballPlayer playerThatScored, int minuteScored)
        {
            PlayerThatScored = playerThatScored;
            MinuteScored = minuteScored;
        }
    }
}

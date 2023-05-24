namespace FootballGame
{
    public abstract class FootballPlayer: Person
    {
        public int Number { get; private set; }
        public double Height { get; private set; }
        public FootballPlayer(string name, int age, int number, double height) : base(name, age)
        {
            Number = number;
            Height = height;
        }

    }
}

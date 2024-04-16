namespace FootBallStandings.Classes
{
    public class Team
    {
        private readonly string team;
        private int points;

        public Team(string team, int points)
        {
            this.team = team;
            this.points = points;
        }

        public bool HaveMorePointsThan(Team otherTeam)
        {
            if (otherTeam == null)
            {
                return false;
            }

            return points > otherTeam.points;
        }

        public void AddPoints(int matchResult)
        {
            points += matchResult;
        }
    }
}

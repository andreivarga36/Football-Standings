using FootBallStandings.Classes;
using Xunit;

namespace FootBallStandingsFacts.Classes
{
    public class TeamFacts
    {
        [Fact]
        public void CompareTeams_InterHaveMorePoints_ShouldReturnTrue()
        {
            Team inter = new("inter", 18);
            Team milan = new("milan", 11);

            Assert.True(inter.HaveMorePointsThan(milan));
        }

        [Fact]
        public void CompareTeams_AtleticoHaveMorePoints_ShouldReturnFalse()
        {
            Team barcelona = new("barcelona", 20);
            Team atletico = new("atletico", 25);

            Assert.False(barcelona.HaveMorePointsThan(atletico));
        }

        [Fact]
        public void CompareTeams_TeamsHaveSamePoints_ShouldReturnFalse()
        {
            Team rapid = new("rapid", 10);
            Team cfr = new("cfr", 10);

            Assert.False(rapid.HaveMorePointsThan(cfr));
        }

        [Fact]
        public void CompareTeams_DefaultTypeValues_ShouldReturnFalse()
        {
            Team arsenal = new(null, 0);
            Team chelsea = new(null, 0);

            Assert.False(arsenal.HaveMorePointsThan(chelsea));
        }


        [Fact]
        public void AddPoints_InterWinsAGameAndHaveMorePoints_ShouldReturnTrue()
        {
            int win = 3;

            Team inter = new("inter", 12);
            Team napoli = new("napoli", 12);
            inter.AddPoints(win);

            Assert.True(inter.HaveMorePointsThan(napoli));
        }

        [Fact]
        public void AddPoints_BayernDrawAndHaveSamePointsAsDortmund_ShouldReturnFalse()
        {
            int draw = 1;

            Team bayern = new("bayern", 10);
            Team dortmund = new("dortmund", 10);
            bayern.AddPoints(draw);
            dortmund.AddPoints(draw);

            Assert.False(bayern.HaveMorePointsThan(dortmund));
        }

        [Fact]
        public void AddPoints_ChelseaLoseAGame_ShouldReturnFalse()
        {
            int win = 3;

            Team chelsea = new("chelsea", 20);
            Team arsenal = new("arsenal", 18);
            arsenal.AddPoints(win);

            Assert.False(chelsea.HaveMorePointsThan(arsenal));
        }

        [Fact]
        public void AddPoints_LiverpoolWins3GamesInARow_ShouldReturnTrue()
        {
            int win = 3;

            Team liverpool = new("liverpool", 22);
            Team tottenham = new("tottenham", 30);
            liverpool.AddPoints(win);
            liverpool.AddPoints(win);
            liverpool.AddPoints(win);

            Assert.True(liverpool.HaveMorePointsThan(tottenham));
        }
    }
}

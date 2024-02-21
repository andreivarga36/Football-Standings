using Xunit;

namespace FootBallStandings
{
    public class StandingsFacts
    {
        [Fact]
        public void AddTeam_AddOneTeam_ShouldReturnTeamName()
        {

            Team interMilan = new ("interMilan", 20);
            Standings standings = new ();
            standings.AddTeam(interMilan);

            Assert.Equal(interMilan, standings.TeamAt(1));
        }

        [Fact]
        public void AddTeam_RomaIsOn3RdPlace_ShouldReturnCorrectTeam()
        {
            Team inter = new ("inter", 15);
            Team milan = new ("milan", 14);
            Team roma = new ("roma", 13);

            Standings standingsList = new ();
            standingsList.AddTeam(inter);
            standingsList.AddTeam(milan);
            standingsList.AddTeam(roma);

            Assert.Equal(roma, standingsList.TeamAt(3));
        }

        [Fact]
        public void TeamAt_JuventusIsOn3RdPlace_ShouldReturnCorrectTeam()
        {
            Team juventus = new ("juventus", 15);
            Team milan = new ("milan", 18);
            Team roma = new ("roma", 20);

            Standings standings = new ();
            standings.AddTeam(juventus);
            standings.AddTeam(milan);
            standings.AddTeam(roma);

            Assert.Equal(juventus, standings.TeamAt(3));
        }

        [Fact]
        public void TeamAt_TottenhamIsOn5ThPlace_ShouldReturnCorrectTeam()
        {
            Team chelsea = new ("chelsea", 22);
            Team arsenal = new ("arsenal", 25);
            Team liverpool = new ("liverpool", 20);
            Team tottenham = new ("tottenham", 18);
            Team leicester = new ("leicester", 21);
             
            Standings standings = new ();
            standings.AddTeam(chelsea);
            standings.AddTeam(arsenal);
            standings.AddTeam(liverpool);
            standings.AddTeam(tottenham);
            standings.AddTeam(leicester);

            Assert.Equal(tottenham, standings.TeamAt(5));
        }

        [Fact]
        public void TeamPosition_VillarealIsOn2NdPlace_ShouldReturnTeamPosition()
        {
            Team realMadrid = new ("realMadrid", 10);
            Team valencia = new ("valencia", 15);
            Team villareal = new ("villareal", 11);

            Standings standings = new ();
            standings.AddTeam(realMadrid);
            standings.AddTeam(valencia);
            standings.AddTeam(villareal);

            Assert.Equal(2, standings.TeamPosition(villareal));
        }

        [Fact]
        public void TeamPosition_ATeamIsOnLastPlace_ShouldReturnTeamPosition()
        {
            Team bayern = new ("bayern", 10);
            Team leverkuzen = new ("leverkuzen", 10);
            Team dortmund = new ("dortmund", 10);
            Team frankfurt = new ("frankfurt", 10);
            Team hertha = new ("hertha", 10);

            Standings standings = new ();
            standings.AddTeam(bayern);
            standings.AddTeam(leverkuzen);
            standings.AddTeam(dortmund);
            standings.AddTeam(frankfurt);
            standings.AddTeam(hertha);

            Assert.Equal(5, standings.TeamPosition(hertha));
        }

        [Fact]
        public void TeamPosition_PetrolulIsNotInStandings_ShouldReturn0()
        {
            Team rapid = new("rapid", 10);
            Team cfr = new("cfr", 14);
            Team petrolul = new("petrolul", 0);
            Team steaua = new("steaua", 19);

            Standings standings = new();
            standings.AddTeam(rapid);
            standings.AddTeam(cfr);
            standings.AddTeam(steaua);

            Assert.Equal(0, standings.TeamPosition(petrolul));
        }

        [Fact]
        public void SortStandings_LiverpoolIsOn1stPlace_ShouldReturnCorrectPosition()
        {
            Team arsenal = new("arsenal", 20);
            Team liverpool = new("liverpool", 29);
            Team chelsea = new("chelsea", 25);

            Standings standings = new();
            standings.AddTeam(arsenal);
            standings.AddTeam(liverpool);
            standings.AddTeam(chelsea);

            Assert.Equal(1, standings.TeamPosition(liverpool));
        }

        [Fact]
        public void SortStandings_BayernIsOnLastPlace_ShouldReturnCorrectPosition()
        {
            Team bayern = new ("bayern", 12);
            Team frankfurt = new ("frankfurt", 16);
            Team dortmund = new ("dortmund", 13);

            Standings standings = new();
            standings.AddTeam(bayern);
            standings.AddTeam(frankfurt);
            standings.AddTeam(dortmund);

            Assert.Equal(3, standings.TeamPosition(bayern));
        }

        [Fact]
        public void UpdateStandings_InterWinAndAdvanceTo1StPlace_ShouldReturnCorrectPosition()
        {
            Team inter = new ("inter", 18);
            Team napoli = new ("napoli", 20);

            Standings standings = new ();
            standings.AddTeam(napoli);
            standings.AddTeam(inter);

            int interGoals = 3;
            int napoliGoals = 1;
            standings.UpdateStandings(inter, napoli, interGoals, napoliGoals);

            Assert.Equal(1, standings.TeamPosition(inter));
        }

        [Fact]
        public void UpdateStandings_RapidLoseAndFallsOnePlaceInStandings_ShouldReturnCorrectPosition()
        {
            Team cfr = new ("cfr", 33);
            Team rapid = new ("rapid", 28);
            Team steaua = new ("steaua", 27);
            Team petrolul = new ("petrolul", 22);

            Standings standings = new ();
            standings.AddTeam(cfr);
            standings.AddTeam(rapid);
            standings.AddTeam(steaua);
            standings.AddTeam(petrolul);

            int steauaGoals = 1;
            int rapidGoals = 0;
            standings.UpdateStandings(steaua, rapid, steauaGoals, rapidGoals);

            Assert.Equal(3, standings.TeamPosition(rapid));
        }

        [Fact]
        public void UpdateStandings_LiverpoolDrawAgainsArsenalAndKeepsHisPlace_ShouldReturnTeamPosition()
        {
            Team arsenal = new ("arsenal", 17);
            Team liverpool = new ("liverpool", 20);

            Standings standings = new ();
            standings.AddTeam(arsenal);
            standings.AddTeam(liverpool);

            int arsenalGoals = 2;
            int liverpoolGoals = 2;
            standings.UpdateStandings(liverpool, arsenal, liverpoolGoals, arsenalGoals);

            Assert.Equal(1, standings.TeamPosition(liverpool));
        }
    }
}

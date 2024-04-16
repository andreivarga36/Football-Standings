using System;

namespace FootBallStandings.Classes
{
    public class Standings
    {
        Team[] standingsList;

        public Standings()
        {
            standingsList = new Team[0];
        }

        public void AddTeam(Team team)
        {
            Array.Resize(ref standingsList, standingsList.Length + 1);
            standingsList[^1] = team;
            SortStandings();
        }

        public Team TeamAt(int position)
        {
            return standingsList[position - 1];
        }

        public int TeamPosition(Team team)
        {
            for (int i = 0; i < standingsList.Length; i++)
            {
                if (standingsList[i] == team)
                {
                    return i + 1;
                }
            }

            return 0;
        }

        public void UpdateStandings(Team homeTeam, Team awayTeam, int homeGoals, int awayGoals)
        {
            if (homeTeam == null || awayTeam == null)
            {
                return;
            }

            ApplyMatchResult(homeTeam, awayTeam, homeGoals, awayGoals);
            SortStandings();
        }

        private void SortStandings()
        {
            bool teamsNotPlacedInDescendingOrder = true;

            while (teamsNotPlacedInDescendingOrder)
            {
                teamsNotPlacedInDescendingOrder = false;

                for (int i = 1; i < standingsList.Length; i++)
                {
                    if (standingsList[i].HaveMorePointsThan(standingsList[i - 1]))
                    {
                        Swap(i - 1, i);
                        teamsNotPlacedInDescendingOrder = true;
                    }
                }
            }
        }

        private void ApplyMatchResult(Team homeTeam, Team awayTeam, int homeGoals, int awayGoals)
        {
            int draw = 1;
            int win = 3;

            if (homeGoals > awayGoals)
            {
                homeTeam.AddPoints(win);
            }
            else if (awayGoals > homeGoals)
            {
                awayTeam.AddPoints(win);
            }
            else
            {
                homeTeam.AddPoints(draw);
                awayTeam.AddPoints(draw);
            }
        }

        private void Swap(int index, int secondIndex)
        {
            Team temp = standingsList[index];
            standingsList[index] = standingsList[secondIndex];
            standingsList[secondIndex] = temp;
        }
    }
}

using FluentAssertions;

using LeagueTable;
using LeagueTable.Domain;


namespace LeagueTableTests
{
    public class Teams_Ordered_By_Points
    {
        todo: https://www.iihf.com/en/events/2024/wmia/tournamentinfo/55238/tournament_info
            Step 4: Should three or more teams still remain tied in points, goal difference and goals scored then the results between each of the three teams and the closest best-ranked team outside the sub-group will be applied.In this case the tied team with the best result (1. points, 2. goal difference, 3. more goals scored) against the closest best ranked-team will take precedence
        [Fact]
        public void And_Played_Once_Home_Beats_Away_Should_Return_Table_With_Home_Top()
        {
            var homeTeam = 1;
            var awayTeam = 2;
            var matchResult = new ResultBuilder().HomeRegulationWin(homeTeam, awayTeam).Build();
            var expectedTeamOrder = new List<int> { homeTeam, awayTeam };
            var sut = new TableCalculator();
            var result = sut.Sort(new List<Result> { matchResult });
            result.Select(x =>x.TeamId).Should().BeEquivalentTo(expectedTeamOrder, options => options.WithStrictOrdering());
        }
        [Fact]
        public void And_Played_Once_Away_Beats_Home_Should_Return_Table_With_Away_Top()
        {
            var homeTeam = 1;
            var awayTeam = 2;
            var matchResult = new ResultBuilder().AwayRegulationWin(homeTeam, awayTeam).Build();
            var expectedTeamOrder = new List<int> { awayTeam, homeTeam };
            var sut = new TableCalculator();

            var result = sut.Sort(new List<Result> { matchResult });

            result.Select(x => x.TeamId).Should().BeEquivalentTo(expectedTeamOrder, options => options.WithStrictOrdering());
        }
    }
}

// Team A Ranked 1 ... Team H
// Team H wins every game 1-0 except v f where 2-0
// Team A losses every game 2-0 except v d where it is 1-0 loss and against h where it is 1-0
// Team b beat team c 1-0
// Team c beats team d 1-0
// team d beats team b 1-0
// team e beats team f 1-0
// team f beats g 1-0
// team g beats e 1-0
// teams e,f and g beat b,c,d all 1-0
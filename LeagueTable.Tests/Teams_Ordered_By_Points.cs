using FluentAssertions;

using LeagueTable;
using LeagueTable.Domain;

namespace LeagueTableTests
{
    public class Teams_Ordered_By_Points
    {
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
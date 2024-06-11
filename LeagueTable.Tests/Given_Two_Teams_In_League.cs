using FluentAssertions;

using LeagueTable;
using LeagueTable.Domain;

namespace LeagueTableTests
{
    public class Given_Two_Teams_In_League
    {
        [Fact]
        public void And_Played_Once_Home_Beats_Away_Should_Return_Table_With_Home_Top()
        {
            var homeTeam = 1;
            var awayTeam = 2;
            var matchResult = new Result() 
            {
                HomeTeamId = homeTeam,
                HomeScore = 1,
                AwayTeamId = awayTeam,
                AwayScore = 0,
                Type = ResultEnum.Regulation
            };
        
         
            var expectedTeamOrder = new List<int> { homeTeam, awayTeam };
            var sut = new TableCalculator();

            var result = sut.Sort(new List<Result> { matchResult });
            
            result.Select(x =>x.TeamId).Should().BeEquivalentTo(expectedTeamOrder, options => options.WithStrictOrdering());
        }
    }
}
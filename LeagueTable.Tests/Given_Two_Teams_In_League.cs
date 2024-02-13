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
        
            var topTeam = new TableEntry
            {
                TeamId = homeTeam,
                Wins = 1,
                Losses = 0,
                OvertimeLosses = 0,
                OvertimeWins = 0,
                GoalsConceded = 0,
                GoalsScored = 1
            };
            var bottomTeam = new TableEntry
            {
                TeamId = awayTeam,
                Wins = 0,
                Losses = 1,
                OvertimeLosses = 0,
                OvertimeWins = 0,
                GoalsConceded = 1,
                GoalsScored = 0
            };
            var expectedTable = new List<TableEntry> { topTeam, bottomTeam };
            var sut = new TableCalculator();

            var result = sut.Sort(new List<Result>());
            
            result.Should().BeEquivalentTo(expectedTable, options => options.WithStrictOrdering());
        }
    }
}
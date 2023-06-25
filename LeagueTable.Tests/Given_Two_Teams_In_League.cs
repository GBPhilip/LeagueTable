using FluentAssertions;

using LeagueTable;
using LeagueTable.Domain;

namespace LeagueTableTests
{
    public class Given_Two_Teams_In_League
    {
        [Fact]
        public void And_Played_Once_Home_Team_Beaten_Away_Team_Should_Return_Table_With_Home_Team_Top()
        {
            var topTeam = new TableEntry
            {
                TeamId = 1,
                Wins = 1,
                Loses = 0,
                OvertimeLoses = 0,
                OvertimeWins = 0,
                GoalsConceded = 0,
                GoalsScored = 1
            };
            var bottomTeam = new TableEntry
            {
                TeamId = 1,
                Wins = 1,
                Loses = 0,
                OvertimeLoses = 0,
                OvertimeWins = 0,
                GoalsConceded = 0,
                GoalsScored = 1
            };
            var expectedTable = new List<TableEntry> { topTeam, bottomTeam };
            var sut = new TableCalculator();

            var result = sut.xxx(new List<Result>());
            
            result.Should().BeEquivalentTo(expectedTable, options => options.WithStrictOrdering());
        }
    }
}
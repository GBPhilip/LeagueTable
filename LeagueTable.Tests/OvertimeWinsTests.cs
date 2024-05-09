using FluentAssertions;
using LeagueTable.Domain;

namespace LeagueTable.Tests
{
    public class OvertimeWinsTests
    {
        const int RED_TEAM = 1;
        const int BLUE_TEAM = 2;

        public OvertimeWinsTests()
        {
        }

        [Fact]
        public void When_Home_Score_Is_Greater_Than_Away_Score_And_Type_Is_Overtime_Should_Return_One_OvertimeWin_For_Home_Team()
        {
            // Arrange
            var results = new List<Result>()
            {
                HomeTeamOvertimeWin()
            };
            var homeTeam = BLUE_TEAM;

            //Act
            var tableEntry = new TableEntry(homeTeam, results);

            // Assert
            tableEntry.OvertimeWins.Should().Be(1);
        }

        private static Result HomeTeamOvertimeWin()
        {
            return new Result()
            {
                AwayTeamId = RED_TEAM,
                AwayScore = 0,
                HomeTeamId = BLUE_TEAM,
                HomeScore = 1,
                Type = ResultEnum.Overtime
            };
        }

    }
}
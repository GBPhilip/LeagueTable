using FluentAssertions;
using LeagueTable.Domain;

namespace LeagueTable.Tests
{
    public class OvertimeLossesTests
    {
        const int RED_TEAM = 1;
        const int BLUE_TEAM = 2;

        public OvertimeLossesTests()
        {
        }

        [Fact]
        public void When_Home_Score_Is_Greater_Than_Away_Score_And_Type_Is_Overtime_Should_Return_One_OvertimeLoss_For_Away_Team()
        {
            // Arrange
            var results = new List<Result>()
            {
                HomeTeamOvertimeWin()
            };
            var awayTeam = RED_TEAM;

            //Act
            var tableEntry = new TableEntry(awayTeam, results);

            // Assert
            tableEntry.OvertimeLosses.Should().Be(1);
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
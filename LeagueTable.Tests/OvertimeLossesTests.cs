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

        [Fact]
        public void When_Home_Score_Is_Greater_Than_Away_Score_And_Type_Is_Overtime_Twice_Should_Return_Two_OvertimeLosses_For_Away_Team()
        {
            // Arrange
            var results = new List<Result>()
            {
                HomeTeamOvertimeWin(),
                HomeTeamOvertimeWin()
            };
            var awayTeam = RED_TEAM;

            //Act
            var tableEntry = new TableEntry(awayTeam, results);

            // Assert
            tableEntry.OvertimeLosses.Should().Be(2);
        }

        [Fact]
        public void When_Away_Score_Is_Greater_Than_Home_Score_And_Type_Is_Overtime_Should_Return_One_OvertimeLoss_For_Home_Team()
        {
            // Arrange

            var awayTeam = RED_TEAM;
            var homeTeam = BLUE_TEAM;

            var results = new List<Result>()
            {
                new ResultBuilder().HomeOvertimeLoss(homeTeam, awayTeam).Build()
            };

            //Act
            var tableEntry = new TableEntry(homeTeam, results);

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
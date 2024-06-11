using AutoFixture;

using FluentAssertions;
using LeagueTable.Domain;

namespace LeagueTable.Tests
{
    public class GoalsScoredTests
    {
        const int RED_TEAM = 1;
        const int BLUE_TEAM = 2;

        public GoalsScoredTests()
        {
        }

        [Fact]
        public void When_Home_Team_Scores_A_Goal_Should_Return_One_As_GoalsScored_For_Home_Team()
        {
            // Arrange
            var homeTeam = RED_TEAM;
            var results = new List<Result>()
            {
                new ResultBuilder()
                .WithHomeTeam(homeTeam)
                .WithHomeGoals(1)
                .WithType(ResultEnum.Overtime)
                .Build()
            };

            //Act
            var tableEntry = new TableEntry(homeTeam, results);

            // Assert
            tableEntry.GoalsScored.Should().Be(1);
        }

        [Fact]
        public void When_Home_Team_Scores_Two_Goals_Should_Return_Two_As_GoalsScored_For_Home_Team()
        {
            // Arrange
            var homeTeam = RED_TEAM;
            var results = new List<Result>()
            {
                new ResultBuilder()
                .WithHomeTeam(homeTeam)
                .WithHomeGoals(2)
                .WithType(ResultEnum.Overtime)
                .Build()
            };

            //Act
            var tableEntry = new TableEntry(homeTeam, results);

            // Assert
            tableEntry.GoalsScored.Should().Be(2);
        }
    }
}
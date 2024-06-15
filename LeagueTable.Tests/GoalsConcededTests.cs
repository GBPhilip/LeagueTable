using AutoFixture;

using FluentAssertions;
using LeagueTable.Domain;

using Ardalis.SmartEnum.AutoFixture;

namespace LeagueTable.Tests
{
    public class GoalsConcededTests
    {
        const int RED_TEAM = 1;
        const int BLUE_TEAM = 2;

        private IFixture _fixture;

        public GoalsConcededTests()
        {
            _fixture = new Fixture().Customize(new SmartEnumCustomization());
        }

        [Fact]
        public void When_Home_Team_Concedes_A_Goal_Should_Return_One_As_GoalsConceded_For_Home_Team()
        {
            // Arrange
            var homeTeam = RED_TEAM;
            var results = new List<Result>()
            {
                _fixture.Build<Result>()
                .With(x => x.HomeTeamId, homeTeam)
                .With(x => x.AwayScore, 1)
                .Create()
            };

            //Act
            var tableEntry = new TableEntry(homeTeam, results);

            // Assert
            tableEntry.GoalsConceded.Should().Be(1);
        }

        [Fact]
        public void When_Home_Team_Concedes_Two_Goals_Should_Return_Two_As_GoalsConceded_For_Home_Team()
        {
            // Arrange
            var homeTeam = RED_TEAM;
            var results = new List<Result>()
            {
                _fixture.Build<Result>()
                .With(x => x.HomeTeamId, homeTeam)
                .With(x => x.AwayScore, 2)
                .Create()
            };


            //Act
            var tableEntry = new TableEntry(homeTeam, results);

            // Assert
            tableEntry.GoalsConceded.Should().Be(2);
        }

        [Fact]
        public void When_Home_Team_Concedes_Two_And_One_Goals_In_Two_Matches_Respectively_Should_Return_Three_As_GoalsConceded_For_Home_Team()
        {
            // Arrange
            var homeTeam = RED_TEAM;
            var results = new List<Result>()
            {
                _fixture.Build<Result>()
                .With(x => x.HomeTeamId, homeTeam)
                .With(x => x.AwayScore, 2)
                .Create(),
                _fixture.Build<Result>()
                .With(x => x.HomeTeamId, homeTeam)
                .With(x => x.AwayScore, 1)
                .Create()
            };

            //Act
            var tableEntry = new TableEntry(homeTeam, results);

            // Assert
            tableEntry.GoalsConceded.Should().Be(3);
        }


        [Fact]
        public void When_Away_Team_Concedes_A_Goal_Should_Return_One_As_GoalsConceded_For_Away_Team()
        {
            // Arrange
            var awayTeam = RED_TEAM;
            var results = new List<Result>()
            {
                _fixture.Build<Result>()
                .With(x => x.AwayTeamId, awayTeam)
                .With(x => x.HomeScore, 1)
                .Create()
            };

            //Act
            var tableEntry = new TableEntry(awayTeam, results);

            // Assert
            tableEntry.GoalsConceded.Should().Be(1);
        }
    }
}
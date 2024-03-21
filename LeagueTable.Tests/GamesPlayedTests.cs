using FluentAssertions;
using LeagueTable.Domain;

namespace LeagueTable.Tests
{
	public class GamesPlayedTests
	{
		public GamesPlayedTests()
		{
		}
        [Fact]
        public void When_Team_Has_One_Win_And_No_Other_Outcomes_Should_Have_Played_One()
        {
            // Arrange
            var tableEntry = new TableEntry()
            {
                Wins = 1,
                Losses = 0,
                OvertimeWins = 0,
                OvertimeLosses = 0
            };

            // Assert
            tableEntry.Played.Should().Be(1);
        }

        [Fact]
        public void When_Team_Has_Two_Wins_And_No_Other_Outcomes_Should_Have_Played_Two()
        {
            // Arrange
            var tableEntry = new TableEntry()
            {
                Wins = 2,
                Losses = 0,
                OvertimeWins = 0,
                OvertimeLosses = 0
            };

            // Assert
            tableEntry.Played.Should().Be(2);
        }

        [Fact]
        public void When_Team_Has_One_Loss_And_No_Other_Outcomes_Should_Have_Played_One()
        {
            // Arrange
            var tableEntry = new TableEntry()
            {
                Wins = 0,
                Losses = 1,
                OvertimeWins = 0,
                OvertimeLosses = 0
            };

            // Assert
            tableEntry.Played.Should().Be(1);
        }
    }
}


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
    }
}


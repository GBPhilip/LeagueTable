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
                RegulationWins = 1,
                RegulationLosses = 0,
                OvertimeWins = 0,
                OvertimeLosses = 0
            };

            // Assert
            tableEntry.Played.Should().Be(1);
        }

        [Fact]
        public void When_Team_Has_Two_RegulationWins_And_No_Other_Outcomes_Should_Have_Played_Two()
        {
            // Arrange
            var tableEntry = new TableEntry()
            {
                RegulationWins = 2,
                RegulationLosses = 0,
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
                RegulationWins = 0,
                RegulationLosses = 1,
                OvertimeWins = 0,
                OvertimeLosses = 0
            };

            // Assert
            tableEntry.Played.Should().Be(1);
        }

        [Fact]
        public void When_Team_Has_One_Loss_In_Overtime_And_No_Other_Outcomes_Should_Have_Played_One()
        {
            // Arrange
            var tableEntry = new TableEntry()
            {
                RegulationWins = 0,
                RegulationLosses = 0,
                OvertimeWins = 0,
                OvertimeLosses = 1
            };

            // Assert
            tableEntry.Played.Should().Be(1);
        }

    }
}


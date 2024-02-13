using System;
using FluentAssertions;
using LeagueTable.Domain;

namespace LeagueTable.Tests
{
	public class PointsCalculationTests
	{
		public PointsCalculationTests()
		{
		}

		[Fact]
		public void When_Team_Has_One_Win_Should_Have_Three_Points()
		{
			// Arrange
			var tableEntry = new TableEntry()
			{
				TeamId = 2,
				Wins = 1
			};

			// Assert
			tableEntry.Points.Should().Be(3); 
		}

		[Fact]
        public void When_Team_Has_Two_Wins_Should_Have_Six_Points()
        {
            // Arrange
            var tableEntry = new TableEntry()
            {
                TeamId = 2,
                Wins = 2
            };

            // Assert
            tableEntry.Points.Should().Be(6);
        }

		[Fact]
		public void When_Team_Has_One_Overtime_Win_Should_Have_Two_Points()
		{
            // Arrange
            var tableEntry = new TableEntry()
            {
                TeamId = 2,
                OvertimeWins = 1
            };

            // Assert
            tableEntry.Points.Should().Be(2);
        }

        [Fact]
        public void When_Team_Has_One_Overtime_Loss_Should_Have_One_Point()
        {
            // Arrange
            var tableEntry = new TableEntry()
            {
                TeamId = 2,
                OvertimeLosses = 1

            };

            // Assert
            tableEntry.Points.Should().Be(1);
        }

    }
}

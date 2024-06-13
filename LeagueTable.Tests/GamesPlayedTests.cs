using Ardalis.SmartEnum.AutoFixture;

using AutoFixture;

using FluentAssertions;
using LeagueTable.Domain;

namespace LeagueTable.Tests
{
	public class GamesPlayedTests
	{
        private IFixture _fixture;
		public GamesPlayedTests()
		{
            _fixture = new Fixture().Customize(new SmartEnumCustomization());
        }
        [Fact]
        public void When_Team_Has_One_Win_And_No_Other_Outcomes_Should_Have_Played_One()
        {
            // Arrange
            var regulationWin = new ResultBuilder2(_fixture).RegulationWin(1);

            var result = new TableEntry(1, new List<Result> { regulationWin });

            // Assert
            result.Played.Should().Be(1);
        }

        [Fact]
        public void When_Team_Has_Two_RegulationWins_And_No_Other_Outcomes_Should_Have_Played_Two()
        {
            var regulationWin = new ResultBuilder2(_fixture).RegulationWin(1);

            var result = new TableEntry(1, new List<Result> { regulationWin, regulationWin });

            // Assert
            result.Played.Should().Be(2);
        }

        [Fact]
        public void When_Team_Has_One_Loss_And_No_Other_Outcomes_Should_Have_Played_One()
        {
            var regulationLoss = new ResultBuilder2(_fixture).RegulationLoss(1);

            var result = new TableEntry(1, new List<Result> { regulationLoss });

            // Assert
            result.Played.Should().Be(1);
        }

        [Fact]
        public void When_Team_Has_One_Loss_In_Overtime_And_No_Other_Outcomes_Should_Have_Played_One()
        {
            // Arrange
            var overtimeLoss = new ResultBuilder2(_fixture).OvertimeLoss(1);

            var result = new TableEntry(1, new List<Result> { overtimeLoss });

            // Assert
            result.Played.Should().Be(1);
        }

    }
}


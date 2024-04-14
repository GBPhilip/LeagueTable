using System;
using FluentAssertions;
using LeagueTable.Domain;

namespace LeagueTable.Tests
{
	public class LossesTests
	{
		public LossesTests()
		{
		}
        [Fact]
        public void When_Home_Score_Is_Greater_Than_Away_Score_And_Type_Is_Regulation_Should_Return_One_Loss_For_Away_Team()
        {
            // Arrange
            var results = new List<Result>()
            { 
                HomeTeamRegulationWin()
            };

            var tableEntry = new TableEntry(1, results);

            // Assert
            tableEntry.Losses.Should().Be(1);
        }
        const int RED_TEAM = 1;
        const int BLUE_TEAM = 2;
        
        private static Result HomeTeamRegulationWin()
        {
            return new Result()
            {
                AwayTeamId = RED_TEAM,
                AwayScore = 0,
                HomeTeamId = BLUE_TEAM,
                HomeScore = 1,
                Type = ResultEnum.Regulation
            };
        }  
    }      

}
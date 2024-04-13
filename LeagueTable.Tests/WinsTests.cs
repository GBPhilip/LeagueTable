using System;
using FluentAssertions;
using LeagueTable.Domain;

namespace LeagueTable.Tests
{
	public class WinsTests
	{
		public WinsTests()
		{
		}
        [Fact]
        public void When_Home_Score_Is_Greater_Than_Away_Score_And_Type_Is_Regulation_Should_Return_One_Win_For_Home_Team()
        {
            // Arrange
            var results = new List<Result>()
            { 
                HomeTeamRegulationWin()
            };

            var tableEntry = new TableEntry(2, results);

            // Assert
            tableEntry.Wins.Should().Be(1);
        }

        [Fact]
        public void When_Home_Score_Is_Greater_Than_Away_Score_And_Type_Is_Regulation_Should_Return_No_Wins_For_Away_Team()
        {
            // Arrange
            var results = new List<Result>()
            {
                HomeTeamRegulationWin()
            };

            var tableEntry = new TableEntry(1, results);

            // Assert
            tableEntry.Wins.Should().Be(0);
        }

        [Fact]
        public void When_Team_Plays_One_Home_And_One_Away_And_Scores_More_Goals_In_Both_Team_Should_Have_Two_Wins()
        {
            // Arrange
            var results = new List<Result>()
            {
                HomeTeamRegulationWin(),
                AwayTeamRegulationWin()
            };

            var tableEntry = new TableEntry(2, results);

            // Assert
            tableEntry.Wins.Should().Be(2);
        }

        [Fact]
        public void When_Team_Plays_One_Home_And_One_Away_And_Scores_More_Goals_In_Both_In_Overtime_Team_Should_Have_Two_OvertimeWins()
        {
            // Arrange
            var results = new List<Result>()
            {
                HomeTeamOvertimeWin(),
                AwayTeamOvertimeWin()
            };

            var tableEntry = new TableEntry(2, results);

            // Assert
            tableEntry.OvertimeWins.Should().Be(2);
        }

        private static Result HomeTeamRegulationWin()
        {
            return new Result()
            {
                AwayTeamId = 1,
                AwayScore = 0,
                HomeTeamId = 2,
                HomeScore = 1,
                Type = ResultEnum.Regulation
            };
        }
        private static Result AwayTeamRegulationWin()
        {
            return new Result()
            {
                AwayTeamId = 2,
                AwayScore = 1,
                HomeTeamId = 1,
                HomeScore = 0,
                Type = ResultEnum.Regulation
            };
        }

        private static Result HomeTeamOvertimeWin()
        {
            return new Result()
            {
                AwayTeamId = 1,
                AwayScore = 0,
                HomeTeamId = 2,
                HomeScore = 1,
                Type = ResultEnum.Overtime
            };
        }
        private static Result AwayTeamOvertimeWin()
        {
            return new Result()
            {
                AwayTeamId = 2,
                AwayScore = 1,
                HomeTeamId = 1,
                HomeScore = 0,
                Type = ResultEnum.Overtime
            };
        }        
    }
}


using System;

using CommunityToolkit.Diagnostics;

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
                new ResultBuilder().HomeRegulationWin(2, 1).Build()
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
                new ResultBuilder().HomeRegulationWin(2, 1).Build()
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
                new ResultBuilder().HomeRegulationWin(2, 1).Build(),
                new ResultBuilder().AwayRegulationWin(2, 1).Build()
            };

            var tableEntry = new TableEntry(2, results);

            // Assert
            tableEntry.Wins.Should().Be(2);
        }

    }

    internal class ResultBuilder
    {
        private int HomeTeamId;
        private int AwayTeamId;
        private int HomeScore;
        private int AwayScore;
        private ResultEnum? Type;
        public ResultBuilder() { }

        public ResultBuilder HomeRegulationWin(int homeId, int awayId)
        {
            HomeTeamId = homeId;
            AwayTeamId = awayId;
            HomeScore = 1;
            AwayScore = 0;
            Type = ResultEnum.Regulation;
            return this;
        }
        public ResultBuilder HomeOvertimeWin(int homeId, int awayId)
        {
            HomeTeamId = homeId;
            AwayTeamId = awayId;
            HomeScore = 1;
            AwayScore = 0;
            Type = ResultEnum.Overtime;
            return this;
        }
        public ResultBuilder RegulationWin(int homeId, int homeGoals, int awayId, int awayGoals)
        {
            Guard.IsTrue(homeGoals > awayGoals);
            HomeTeamId = homeId;
            AwayTeamId = awayId;
            HomeScore = 1;
            AwayScore = 0;
            Type = ResultEnum.Regulation;
            return this;
        }

        public ResultBuilder AwayRegulationWin(int homeId, int awayId)
        {
            HomeTeamId = homeId;
            AwayTeamId = awayId;
            HomeScore = 1;
            AwayScore = 0;
            Type = ResultEnum.Regulation;
            return this;
        }
        public ResultBuilder AwayOvertimeWin(int homeId, int awayId)
        {
            HomeTeamId = homeId;
            AwayTeamId = awayId;
            HomeScore = 1;
            AwayScore = 0;
            Type = ResultEnum.Overtime;
            return this;
        }

        public ResultBuilder OvertimeWin(int homeId, int homeGoals, int awayId, int awayGoals)
        {
            Guard.IsTrue(homeGoals > awayGoals);
            HomeTeamId = homeId;
            AwayTeamId = awayId;
            HomeScore = 1;
            AwayScore = 0;
            Type = ResultEnum.Overtime;
            return this;
        }
        public Result Build()
        {
            Guard.IsNotNull(Type);
            return new Result
            {
                HomeScore = HomeScore,
                HomeTeamId = HomeTeamId,
                AwayScore = AwayScore,
                AwayTeamId = AwayTeamId,
                Type = Type
            };
        }
    }
}


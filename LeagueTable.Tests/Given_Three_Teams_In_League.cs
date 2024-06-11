using FluentAssertions;

using LeagueTable;
using LeagueTable.Domain;

namespace LeagueTableTests
{
    public class Given_Three_Teams_In_League
    {
        const int redTeam = 1;
        const int blueTeam = 2;
        const int greenTeam = 3;
        private List<TableEntry> Result;
        public Given_Three_Teams_In_League()
        {
            var matchResults = new List<Result>
            {
                new ResultBuilder().RegulationWin(redTeam, 2, blueTeam,0).Build(),
                new ResultBuilder().RegulationWin(blueTeam, 2, greenTeam,0).Build(),
                new ResultBuilder().RegulationWin(greenTeam, 1, redTeam,0).Build()
            };

            var sut = new TableCalculator();

            Result = sut.Sort(matchResults);
        }

        [Fact]
        public void And_Played_Once_Each_Team_Once_Three_Teams_In_Table()
        {
            Result.Count.Should().Be(3);
        }

        [Fact]
        public void And_Played_Once_Each_Team_Once_Red_Teams_Wins()
        {
            Result.First().TeamId.Should().Be(redTeam);
        }    
    }
}
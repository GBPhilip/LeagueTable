using FluentAssertions;

using LeagueTable;
using LeagueTable.Domain;

using System.Collections;

namespace LeagueTableTests
{
    public class Teams_Ordered_By_Goal_Difference_Within_Points1
    {
        const int redTeam = 1;
        const int blueTeam = 2;
        const int greenTeam = 3;
        const int purpleTeam = 4;
        public Teams_Ordered_By_Goal_Difference_Within_Points1()
        {
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator1))]
        public void And_Played_Once_Each_Team_Once_Four_Teams_In_Table(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.Count.Should().Be(4);
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator1))]
        public void And_Played_Once_Each_Team_Once_Purple_Teams_Wins(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.First().TeamId.Should().Be(purpleTeam);
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator1))]
        public void And_Played_Once_Each_Team_Once_Red_Teams_Finishes_Second(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.Skip(1).Take(1).First().TeamId.Should().Be(redTeam);
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator1))]
        public void And_Played_Once_Each_Team_Once_Green_Teams_Finishes_Last(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.Last().TeamId.Should().Be(blueTeam);
        }
    }

    public class TestResultGenerator1 : IEnumerable<object[]>
    {
        const int redTeam = 1;
        const int blueTeam = 2;
        const int greenTeam = 3;
        const int purpleTeam = 4;

        private readonly List<object[]> _data = new();
        public TestResultGenerator1()
        {
            var redWin = new ResultBuilder().RegulationWin(redTeam, 10, blueTeam, 0).Build();
            var blueWin = new ResultBuilder().RegulationWin(blueTeam, 2, greenTeam, 0).Build();
            var greenWin = new ResultBuilder().RegulationWin(greenTeam, 1, redTeam, 0).Build();
            var purpleWinRed = new ResultBuilder().RegulationWin(purpleTeam, 1, redTeam, 0).Build();
            var purpleWinBlue = new ResultBuilder().RegulationWin(purpleTeam, 1, blueTeam, 0).Build();
            var purpleWinGreen = new ResultBuilder().RegulationWin(purpleTeam, 1, greenTeam, 0).Build();

            _data.Add(new object[] { new List<Result> { redWin, blueWin, greenWin, purpleWinBlue, purpleWinGreen, purpleWinRed } });
            _data.Add(new object[] { new List<Result> { greenWin, blueWin, redWin, purpleWinBlue, purpleWinGreen, purpleWinRed } });
            _data.Add(new object[] { new List<Result> { blueWin, redWin, greenWin, purpleWinBlue, purpleWinGreen, purpleWinRed } });
        }
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
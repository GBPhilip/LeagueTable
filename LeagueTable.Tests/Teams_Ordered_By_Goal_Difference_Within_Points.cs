using FluentAssertions;

using LeagueTable;
using LeagueTable.Domain;

using System.Collections;

namespace LeagueTableTests
{
    public class Teams_Ordered_By_Goal_Difference_Within_Points
    {
        const int redTeam = 1;
        const int blueTeam = 2;
        const int greenTeam = 3;
        public Teams_Ordered_By_Goal_Difference_Within_Points()
        {
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator))]
        public void And_Played_Once_Each_Team_Once_Three_Teams_In_Table(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.Count.Should().Be(3);
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator))]
        public void And_Played_Once_Each_Team_Once_Red_Teams_Wins(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.First().TeamId.Should().Be(redTeam);
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator))]
        public void And_Played_Once_Each_Team_Once_Blue_Teams_Finishes_Second(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.Skip(1).Take(1).First().TeamId.Should().Be(blueTeam);
        }
        [Theory]
        [ClassData(typeof(TestResultGenerator))]
        public void And_Played_Once_Each_Team_Once_Green_Teams_Finishes_Last(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.Last().TeamId.Should().Be(greenTeam);
        }
    }

    public class TestResultGenerator : IEnumerable<object[]>
    {
        const int redTeam = 1;
        const int blueTeam = 2;
        const int greenTeam = 3;

        private readonly List<object[]> _data = new();
        public TestResultGenerator()
        {
            var redWin = new ResultBuilder().RegulationWin(redTeam, 2, blueTeam, 0).Build();
            var blueWin = new ResultBuilder().RegulationWin(blueTeam, 2, greenTeam, 0).Build();
            var greenWin = new ResultBuilder().RegulationWin(greenTeam, 1, redTeam, 0).Build();

            _data.Add(new object[] { new List<Result> { redWin, blueWin, greenWin } });
            _data.Add(new object[] { new List<Result> { greenWin, blueWin, redWin }});
            _data.Add(new object[] { new List<Result> { blueWin, redWin, greenWin } });
        }
        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
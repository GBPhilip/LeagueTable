using Ardalis.SmartEnum.AutoFixture;

using AutoFixture;

using FluentAssertions;

using LeagueTable;
using LeagueTable.Domain;

using System.Collections;

namespace LeagueTableTests
{
    public class Teams_Ordered_By_Goal_Difference_Within_2Groups
    {
        const int redTeam = 1;
        const int blueTeam = 2;
        const int greenTeam = 3;
        const int purpleTeam = 4;
        public Teams_Ordered_By_Goal_Difference_Within_2Groups()
        {
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator))]
        public void And_Played_Once_Each_Team_Once_Four_Teams_In_Table(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.Count.Should().Be(4);
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator))]
        public void And_Played_Once_Each_Team_Once_Red_Team_Wins(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.First().TeamId.Should().Be(redTeam);
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator))]
        public void And_Played_Once_Each_Team_Once_Blue_Team_Finishes_Second(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.Skip(1).Take(1).First().TeamId.Should().Be(blueTeam);
        }

        [Theory]
        [ClassData(typeof(TestResultGenerator))]
        public void And_Played_Once_Each_Team_Once_Purple_Teams_Finishes_Last(List<Result> matchResults)
        {
            var sut = new TableCalculator();

            var result = sut.Sort(matchResults);
            result.Last().TeamId.Should().Be(purpleTeam);
        }


        private class TestResultGenerator : IEnumerable<object[]>
        {
            const int redTeam = 1;
            const int blueTeam = 2;
            const int greenTeam = 3;
            const int purpleTeam = 4;

            private readonly List<object[]> _data = new();
            public TestResultGenerator()
            {
                var fixture = new Fixture().Customize(new SmartEnumCustomization());
                var redBeatBlue = fixture.Build<Result>()
                    .With(x => x.HomeTeamId, redTeam)
                    .With(x => x.HomeScore, 1)
                    .With(x => x.AwayTeamId, blueTeam)
                    .With(x => x.AwayScore, 0)
                    .With(x=> x.Type, ResultEnum.Regulation)
                    .Create();
                var blueBeatGreen = fixture.Build<Result>()
                    .With(x => x.HomeTeamId, blueTeam)
                    .With(x => x.HomeScore, 2)
                    .With(x => x.AwayTeamId, greenTeam)
                    .With(x => x.AwayScore, 0)
                    .With(x => x.Type, ResultEnum.Regulation)
                    .Create();
                var greenBeatPurple = fixture.Build<Result>()
                    .With(x => x.HomeTeamId, greenTeam)
                    .With(x => x.HomeScore, 3)
                    .With(x => x.AwayTeamId, purpleTeam)
                    .With(x => x.AwayScore, 0)
                    .With(x => x.Type, ResultEnum.Regulation)
                    .Create();
                _data.Add(new object[] { new List<Result> { redBeatBlue, blueBeatGreen, greenBeatPurple, } });
                _data.Add(new object[] { new List<Result> { blueBeatGreen, redBeatBlue, greenBeatPurple, } });
            }
            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
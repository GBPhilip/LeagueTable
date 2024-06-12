using AutoFixture;

using CommunityToolkit.Diagnostics;
using LeagueTable.Domain;

internal class ResultBuilder2
{
    private readonly IFixture _fixture;
    public ResultBuilder2(IFixture fixture)
    {
        _fixture = fixture;
    }
    public Result HomeRegulationWin(int homeId, int awayId)
    {
        Guard.IsNotEqualTo(homeId, awayId);
        var generator = _fixture.Create<Generator<int>>();
        var homeScore = _fixture.Create<int>();
        var awayScore = generator.Where(x => x < homeScore).First();
        return _fixture.Build<Result>()
            .With(x => x.HomeTeamId, homeId)
            .With(x => x.AwayTeamId, awayId)
            .With(x => x.HomeScore, homeScore)
            .With(x => x.AwayScore, awayScore)
            .With(x => x.Type, ResultEnum.Regulation)
            .Create();
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

    public ResultBuilder WithHomeTeam(int id)
    {
        Guard.IsNotEqualTo(id, AwayTeamId);
        HomeTeamId = id;
        return this;
    }

    public ResultBuilder WithHomeGoals(int goals)
    {
        Guard.IsGreaterThanOrEqualTo(goals,0);
        HomeScore = goals;
        return this;
    }

    public ResultBuilder WithAwayGoals(int goals)
    {
        Guard.IsGreaterThanOrEqualTo(goals, 0);
        AwayScore = goals;
        return this;
    }

    public ResultBuilder WithAwayTeam(int id)
    {
        Guard.IsNotEqualTo(id, HomeTeamId);
        AwayTeamId = id;
        return this;
    }

    public ResultBuilder WithType(ResultEnum type)
    {
        Guard.IsNotNull(type);
        Type = type;
        return this;
    }
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
        Guard.IsGreaterThan(homeGoals, awayGoals);
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
        HomeScore = 0;
        AwayScore = 1;
        Type = ResultEnum.Regulation;
        return this;
    }
    public ResultBuilder AwayOvertimeWin(int homeId, int awayId)
    {
        HomeTeamId = homeId;
        AwayTeamId = awayId;
        HomeScore = 0;
        AwayScore = 1;
        Type = ResultEnum.Overtime;
        return this;
    }

    public ResultBuilder HomeOvertimeLoss(int homeId, int awayId)
    {
        return AwayOvertimeWin(homeId, awayId);
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
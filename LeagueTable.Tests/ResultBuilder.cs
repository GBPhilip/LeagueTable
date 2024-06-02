using CommunityToolkit.Diagnostics;
using LeagueTable.Domain;

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

    public ResultBuilder WithAwayTeam(int id)
    {
        Guard.IsNotEqualTo(id, HomeTeamId);
        AwayTeamId = id;
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
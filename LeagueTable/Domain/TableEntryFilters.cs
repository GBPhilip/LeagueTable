namespace LeagueTable.Domain
{
    internal static class TableEntryFilters
    {
        internal static IEnumerable<Result> HomeWinsInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore > x.AwayScore
                && x.HomeTeamId == teamId
                && x.Type == ResultEnum.Regulation);
        }

        internal static IEnumerable<Result> AwayWinsInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x => 
                   x.HomeScore < x.AwayScore
                && x.AwayTeamId == teamId
                && x.Type == ResultEnum.Regulation);
        }

        internal static IEnumerable<Result> HomeWinsInOvertime(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore > x.AwayScore
                && x.HomeTeamId == teamId
                && x.Type == ResultEnum.Overtime);
        }

        internal static IEnumerable<Result> AwayWinsInOvertime(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x => 
                   x.HomeScore < x.AwayScore
                && x.AwayTeamId == teamId
                && x.Type == ResultEnum.Overtime);
        }
        internal static IEnumerable<Result> HomeLossesInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore < x.AwayScore
                && x.HomeTeamId == teamId
                && x.Type == ResultEnum.Regulation);
        }

        internal static IEnumerable<Result> AwayLossesInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x => 
                   x.HomeScore > x.AwayScore
                && x.AwayTeamId == teamId
                && x.Type == ResultEnum.Regulation);
        }
    }
}
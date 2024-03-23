namespace LeagueTable.Domain
{
    internal static class TableEntryFilters
    {
        internal static IEnumerable<Result> HomeWinsInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x => x.HomeScore > x.AwayScore && x.HomeTeamId == teamId);
        }
    }
}
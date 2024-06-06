namespace LeagueTable.Domain
{
    internal static class TableEntryFilters
    {
        /// <summary>
        /// Filter to return home wins in regulation time for the specified team from the results
        /// </summary>
        /// <param name="results">The set of results to filter</param>
        /// <param name="teamId">The id of the team that the home wins in regulation time</param>
        /// <returns>The filtered results</returns>
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

        internal static IEnumerable<Result> HomeLossesInOvertime(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore < x.AwayScore
                && x.HomeTeamId == teamId
                && x.Type == ResultEnum.Overtime);
        }

        internal static IEnumerable<Result> AwayLossesInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore > x.AwayScore
                && x.AwayTeamId == teamId
                && x.Type == ResultEnum.Regulation);
        }
        internal static IEnumerable<Result> AwayLossesInOvertime(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore > x.AwayScore
                && x.AwayTeamId == teamId
                && x.Type == ResultEnum.Overtime);
        }
    }
}
namespace LeagueTable.Domain
{
    internal static class TableEntryFilters
    {
        /// <summary>
        /// Filter to return home wins in regulation time for the specified team from the results
        /// </summary>
        /// <param name="results">The set of results to filter</param>
        /// <param name="teamId">The id of the team that the home wins in regulation time results are filtered for</param>
        /// <returns>The filtered results</returns>
        internal static IEnumerable<Result> HomeWinsInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore > x.AwayScore
                && x.HomeTeamId == teamId
                && x.Type == ResultEnum.Regulation);
        }

        /// <summary>
        /// Filter to return away wins in regulation time for the specified team from the results
        /// </summary>
        /// <param name="results">The set of results to filter</param>
        /// <param name="teamId">The id of the team that the away wins in regulation time results are filtered for</param>
        /// <returns>The filtered results</returns>
        internal static IEnumerable<Result> AwayWinsInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore < x.AwayScore
                && x.AwayTeamId == teamId
                && x.Type == ResultEnum.Regulation);
        }

        /// <summary>
        /// Filter to return home wins in overtime time for the specified team from the results
        /// </summary>
        /// <param name="results">The set of results to filter</param>
        /// <param name="teamId">The id of the team that the home wins in overtime time results are filtered for</param>
        /// <returns>The filtered results</returns>
        internal static IEnumerable<Result> HomeWinsInOvertime(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore > x.AwayScore
                && x.HomeTeamId == teamId
                && x.Type == ResultEnum.Overtime);
        }

        /// <summary>
        /// Filter to return away wins in overtime time for the specified team from the results
        /// </summary>
        /// <param name="results">The set of results to filter</param>
        /// <param name="teamId">The id of the team that the away wins in overtime time results are filtered for</param>
        /// <returns>The filtered results</returns>
        internal static IEnumerable<Result> AwayWinsInOvertime(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore < x.AwayScore
                && x.AwayTeamId == teamId
                && x.Type == ResultEnum.Overtime);
        }

        /// <summary>
        /// Filter to return home losses in regulation time for the specified team from the results
        /// </summary>
        /// <param name="results">The set of results to filter</param>
        /// <param name="teamId">The id of the team that the home losses in regulation time results are filtered for</param>
        /// <returns>The filtered results</returns>
        internal static IEnumerable<Result> HomeLossesInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore < x.AwayScore
                && x.HomeTeamId == teamId
                && x.Type == ResultEnum.Regulation);
        }

        /// <summary>
        /// Filter to return away losses in regulation time for the specified team from the results
        /// </summary>
        /// <param name="results">The set of results to filter</param>
        /// <param name="teamId">The id of the team that the away losses in regulation time results are filtered for</param>
        /// <returns>The filtered results</returns>
        internal static IEnumerable<Result> AwayLossesInRegulation(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore > x.AwayScore
                && x.AwayTeamId == teamId
                && x.Type == ResultEnum.Regulation);
        }

        /// <summary>
        /// Filter to return home losses in overtime time for the specified team from the results
        /// </summary>
        /// <param name="results">The set of results to filter</param>
        /// <param name="teamId">The id of the team that the home losses in overtime time results are filtered for</param>
        /// <returns>The filtered results</returns>
        internal static IEnumerable<Result> HomeLossesInOvertime(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore < x.AwayScore
                && x.HomeTeamId == teamId
                && x.Type == ResultEnum.Overtime);
        }

        /// <summary>
        /// Filter to return away losses in overtime time for the specified team from the results
        /// </summary>
        /// <param name="results">The set of results to filter</param>
        /// <param name="teamId">The id of the team that the away losses in overtime time results are filtered for</param>
        /// <returns>The filtered results</returns>
        internal static IEnumerable<Result> AwayLossesInOvertime(this IEnumerable<Result> results, int teamId)
        {
            return results.Where(x =>
                   x.HomeScore > x.AwayScore
                && x.AwayTeamId == teamId
                && x.Type == ResultEnum.Overtime);
        }
    }
}
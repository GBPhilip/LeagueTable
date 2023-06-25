namespace LeagueTable.Domain
{
    /// <summary>
    /// Result stores the result of one game
    /// </summary>
    internal class Result
    {
        /// <summary>
        /// HomeTeamId is the key to reference which team was designated as the home team
        /// </summary>
        public int HomeTeamId { get; set; }
        /// <summary>
        /// HomeScore is the number of goals credited the home team
        /// </summary>
        public int HomeScore { get; set; }
        /// <summary>
        /// AwayTeamId is the key to reference which team was designated as the home team
        /// </summary>
        public int AwayTeamId { get; set; }
        /// <summary>
        /// AwayScore is the number of goals credited the home team
        /// </summary>
        public int AwayScore { get; set; }
        public required ResultEnum Type { get; set; }
    }
}

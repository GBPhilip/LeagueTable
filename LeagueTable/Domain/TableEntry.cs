namespace LeagueTable.Domain
{
    /// <summary>
    /// A row that stores the information from a team's row in a league table
    /// </summary>
    internal class TableEntry
    {
        /// <summary>
        /// The id of the team of the table entry
        /// </summary>
        public int TeamId { get; set; }
        /// <summary>
        /// The number of wins by a team in regulatory time
        /// </summary>
        public int Wins { get; set; }
        /// <summary>
        /// The number of wins by a team in overtime/penalty shots
        /// </summary>
        public int OvertimeWins { get; set; }
        /// <summary>
        /// The number of losses by a team in overtime/penalty shots
        /// </summary>
        public int OvertimeLosses { get; set; }
        /// <summary>
        /// The number of losses by a team in regulatory time
        /// </summary>
        public int Losses { get; set; }
        /// <summary>
        /// The number of wins by a team in regulatory time
        /// </summary>
        public int GoalsScored { get; set; }
        /// <summary>
        /// The number of wins by a team in regulatory time
        /// </summary>
        public int GoalsConceded { get; set; }
        /// <summary>
        /// The number of points achieved by the team
        /// </summary>
        public int Points { get => (Wins * 3) + (OvertimeWins * 2) + (OvertimeLoses * 1); }
    }
}

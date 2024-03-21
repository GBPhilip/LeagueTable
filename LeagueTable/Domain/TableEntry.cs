using CommunityToolkit.Diagnostics;

namespace LeagueTable.Domain
{
    /// <summary>
    /// A row that stores the information from a team's row in a league table
    /// </summary>
    internal class TableEntry
    {
        private IEnumerable<Result> _results { get; }

        public TableEntry() { }

        public TableEntry(int teamId, IEnumerable<Result> results)
        {
            Guard.IsNotNull(results);

            TeamId = teamId;
            _results = results;

            Wins = CalculateWins();
        }

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
        public int Points { get => (Wins * 3) + (OvertimeWins * 2) + (OvertimeLosses * 1); }
        /// <summary>
        /// The number of games played by the team
        /// </summary>
        public int Played { get => Wins + Losses + OvertimeWins + OvertimeLosses; }

        private int CalculateWins()
        {
            var wins = 0;

            foreach (var result in _results)
            {
                if(result.HomeScore > result.AwayScore && result.HomeTeamId == TeamId)
                {
                    wins++;
                }
            }

            return wins;
        }
    }
}
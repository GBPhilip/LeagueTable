using CommunityToolkit.Diagnostics;

using System.Runtime.CompilerServices;

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

            RegulationWins = CalculateRegulationWins();
            OvertimeWins = CalculateOvertimeWins();
            RegulationLosses = CalculateRegulationLosses();
        }

        /// <summary>
        /// The id of the team of the table entry
        /// </summary>
        public int TeamId { get; set; }

        /// <summary>
        /// The number of wins by a team in regulation time
        /// </summary>
        public int RegulationWins { get; set; }
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
        public int RegulationLosses { get; set; }
        /// <summary>
        /// The number of goals scored by a team at the end of a game
        /// </summary>
        public int GoalsScored { get; set; }
        /// <summary>
        /// The number of goals conceded by a team at the end of a game
        /// </summary>
        public int GoalsConceded { get; set; }
        /// <summary>
        /// The number of points achieved by the team
        /// </summary>
        public int Points { get => (RegulationWins * 3) + (OvertimeWins * 2) + (OvertimeLosses * 1); }
        /// <summary>
        /// The number of games played by the team
        /// </summary>
        public int Played { get => RegulationWins + RegulationLosses + OvertimeWins + OvertimeLosses; }
        /// <summary>
        /// A method to calculate the number of wins in regulation time for the team
        /// </summary>
        /// <returns>An integer</returns>
        private int CalculateRegulationWins() =>
            _results.HomeWinsInRegulation(TeamId).Count()
          + _results.AwayWinsInRegulation(TeamId).Count();
        /// <summary>
        /// A method to calculate the number of wins in overtime time for the team
        /// </summary>
        /// <returns>An integer</returns>
        private int CalculateOvertimeWins() =>
            _results.HomeWinsInOvertime(TeamId).Count()
          + _results.AwayWinsInOvertime(TeamId).Count();
        /// <summary>
        /// A method to calculate the number of losses in regulation time for the team
        /// </summary>
        /// <returns>An integer</returns>
        private int CalculateRegulationLosses() =>
            _results.HomeLossesInRegulation(TeamId).Count()
          + _results.AwayLossesInRegulation(TeamId).Count();
          
    }
}
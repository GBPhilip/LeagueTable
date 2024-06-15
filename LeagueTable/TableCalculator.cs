using LeagueTable.Domain;

namespace LeagueTable
{
    internal class TableCalculator
    {
        public TableCalculator() { }
        public List<TableEntry> Sort(List<Result> results)
        {          
            var teams = results.Select(x => x.HomeTeamId).Union(results.Select(x => x.AwayTeamId)).Distinct();
            var tableEntries = new List<TableEntry>();
            foreach (var team in teams)
            {
                tableEntries.Add(new TableEntry(team, results));
            }
            
            var sortedTableRows = tableEntries.OrderByDescending(x => x.Points).ToList();
            var teamsOnSamePoints = sortedTableRows.GroupBy(x => x.Points);
            if (teamsOnSamePoints.Count() == teams.Count())
            {
                return sortedTableRows;
            }

            var x =tableEntries.OrderByDescending(x => (x.GoalsScored-x.GoalsConceded)).ToList();
            return x;
        }
    }
}
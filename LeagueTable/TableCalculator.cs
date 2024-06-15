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
            return tableEntries.OrderByDescending(x => x.Points).ToList(); ;
        }
    }
}
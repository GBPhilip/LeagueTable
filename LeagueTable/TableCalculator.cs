using LeagueTable.Domain;

namespace LeagueTable
{
    internal class TableCalculator
    {
        public TableCalculator() { }
        public List<TableEntry> Sort(List<Result> results)
        {
            var firstTeam = new TableEntry(1, results);
            var secondTeam = new TableEntry(2, results);
            var tableEntries = new List<TableEntry> { firstTeam, secondTeam};
            return tableEntries.OrderByDescending(x => x.Points).ToList(); ;
        }
    }
}
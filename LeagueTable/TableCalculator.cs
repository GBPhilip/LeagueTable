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
            return new List<TableEntry> { firstTeam, secondTeam };
        }
    }
}
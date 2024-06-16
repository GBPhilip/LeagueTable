using LeagueTable.Domain;

namespace LeagueTable
{
    internal class TableCalculator
    {
        public TableCalculator() { }
        public List<TableEntry> Sort(List<Result> results)
        {
            var teams = results.Select(x => x.HomeTeamId).Union(results.Select(x => x.AwayTeamId)).Distinct().ToList();
            var tableEntries = CreateTable(results, teams);

            var teamsGroupedBySamePoints = tableEntries.GroupBy(x => x.Points).OrderByDescending(x => x.Key).ToList();
            if (teamsGroupedBySamePoints.Count() == teams.Count)
            {
                return tableEntries.OrderByDescending(x => x.Points).ToList();
            }
            var calculatedTable = new List<TableEntry>();
            calculatedTable.Add(teamsGroupedBySamePoints.First().First());

            var runnersUp = teamsGroupedBySamePoints.Skip(1).Take(1).First();
            var teamsInGroup = runnersUp.Select(x => x.TeamId).ToList();
            var relevantResults = results.Where(x => teamsInGroup.Contains(x.HomeTeamId) && teamsInGroup.Contains(x.AwayTeamId)).ToList();

            var table = CreateTable(relevantResults, teamsInGroup);
            
            calculatedTable.AddRange(table.OrderByDescending(x => x.GoalsScored-x.GoalsConceded));
            return calculatedTable;

        }

        private static List<TableEntry> CreateTable(List<Result> results, List<int> teams)
        {
            List<TableEntry> tableEntries = new(); 
            foreach (var team in teams)
            {
                tableEntries.Add(new TableEntry(team, results));
            }
            return tableEntries;
        }
    }
}
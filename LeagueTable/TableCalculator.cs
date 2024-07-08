using LeagueTable.Domain;

namespace LeagueTable
{
    internal class TableCalculator
    {
        public TableCalculator() { }
        public List<TableEntry> Sort(List<Result> results)
        {
            var teams = results.Select(x => x.HomeTeamId).Union(results.Select(x => x.AwayTeamId)).Distinct().ToList();
            // var tableEntries = CreateTable(results, teams);
            var calculatedTable = new IIHFSorter().Sort(results, teams);
            //var teamsGroupedBySamePoints = tableEntries.GroupBy(x => x.Points).OrderByDescending(x => x.Key).ToList();
            //if (teamsGroupedBySamePoints.Count == teams.Count)
            //{
            //    return tableEntries.OrderByDescending(x => x.Points).ToList();
            //}

            //var calculatedTable = new List<TableEntry>();
            //foreach (var pointsGroup in teamsGroupedBySamePoints)
            //{
            //    if (pointsGroup.Count() == 1)
            //    {
            //        calculatedTable.Add(pointsGroup.First());
            //    }
            //    else
            //    {
            //        var teamsInGroup = pointsGroup.Select(x => x.TeamId).ToList();
            //        var relevantResults = results.Where(x => teamsInGroup.Contains(x.HomeTeamId) && teamsInGroup.Contains(x.AwayTeamId)).ToList();
            //        var table = CreateTable(relevantResults, teamsInGroup);

            //        if (teams.Count == teamsInGroup.Count)
            //        {
            //            calculatedTable.AddRange(table.OrderByDescending(x => x.GoalsScored - x.GoalsConceded));
            //        }
            //        else
            //        {
            //            calculatedTable.AddRange(Sort(relevantResults));
            //        }
            //    }
            //}

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

    internal abstract class SortHandler
    {
        protected SortHandler _successor;

        public void SetSuccessor(SortHandler successor)
        {
            _successor = successor;
        }
        public abstract List<TableEntry> Sort(List<Result> results, List<int> teams);
        protected static List<TableEntry> CreateTable(List<Result> results, List<int> teams)
        {
            List<TableEntry> tableEntries = new();
            foreach (var team in teams)
            {
                tableEntries.Add(new TableEntry(team, results));
            }
            return tableEntries;
        }
    }

    internal class SortByPoints : SortHandler
    {
        public override List<TableEntry> Sort(List<Result> results, List<int> teams)
        {
            var resultsForTeams = results.Where(x => teams.Contains(x.HomeTeamId) && teams.Contains(x.AwayTeamId)).ToList();
            var tableEntries = CreateTable(resultsForTeams, teams);

            var teamsGroupedBySamePoints = tableEntries.GroupBy(x => x.Points).OrderByDescending(x => x.Key).ToList();
            if (teamsGroupedBySamePoints.Count == teams.Count)
            {
                return tableEntries.OrderByDescending(x => x.Points).ToList();
            }
            var calculatedTable = new List<TableEntry>();
            foreach (var pointsGroup in teamsGroupedBySamePoints)
            {
                if (pointsGroup.Count() == 1)
                {
                    calculatedTable.Add(pointsGroup.First());
                }
                else if (pointsGroup.Count() == teams.Count)
                {
                    if (_successor != null)
                    {
                        var teamsInGroup = pointsGroup.Select(x => x.TeamId).ToList();
                        calculatedTable.AddRange(_successor.Sort(resultsForTeams, teamsInGroup));
                    }
                }
                else
                {
                    var teamsInGroup = pointsGroup.Select(x => x.TeamId).ToList();
                    calculatedTable.AddRange(new IIHFSorter().Sort(resultsForTeams, teamsInGroup));
                }
            }
            return calculatedTable;
        }
    }

    internal class SortByGoalDifference : SortHandler
    {
        public override List<TableEntry> Sort(List<Result> results, List<int> teams)
        {
            var resultsForTeams = results.Where(x => teams.Contains(x.HomeTeamId) && teams.Contains(x.AwayTeamId)).ToList();
            var tableEntries = CreateTable(resultsForTeams, teams);

            var teamsGroupedBySameGoalDifference = tableEntries.GroupBy(x => (x.GoalsScored - x.GoalsConceded)).OrderByDescending(x => x.Key).ToList();
            if (teamsGroupedBySameGoalDifference.Count == teams.Count)
            {
                return tableEntries.OrderByDescending(x => (x.GoalsScored - x.GoalsConceded)).ToList();
            }
            var calculatedTable = new List<TableEntry>();
            foreach (var goalsDifferenceGroup in teamsGroupedBySameGoalDifference)
            {
                if (goalsDifferenceGroup.Count() == 1)
                {
                    calculatedTable.Add(goalsDifferenceGroup.First());
                }
                else if (goalsDifferenceGroup.Count() == teams.Count)
                {
                    if (_successor != null)
                    {
                        calculatedTable.AddRange(_successor.Sort(resultsForTeams, teams));
                    }
                }
                else
                {
                    var teamsInGroup = goalsDifferenceGroup.Select(x => x.TeamId).ToList();
                    calculatedTable.AddRange(new IIHFSorter().Sort(resultsForTeams, teamsInGroup));
                }
            }
            return calculatedTable;
        }
    }

internal class SortByGoalsScored : SortHandler
    {
        public override List<TableEntry> Sort(List<Result> results, List<int> teams)
        {
            var resultsForTeams = results.Where(x => teams.Contains(x.HomeTeamId) && teams.Contains(x.AwayTeamId)).ToList();
            var tableEntries = CreateTable(resultsForTeams, teams);

            var teamsGroupedBySameGoalScored = tableEntries.GroupBy(x => x.GoalsScored).OrderByDescending(x => x.Key).ToList();
            if (teamsGroupedBySameGoalScored.Count == teams.Count)
            {
                return tableEntries.OrderByDescending(x => x.Points).ToList();
            }
            var calculatedTable = new List<TableEntry>();
            foreach (var goalsScoredGroup in teamsGroupedBySameGoalScored)
            {
                if (goalsScoredGroup.Count() == 1)
                {
                    calculatedTable.Add(goalsScoredGroup.First());
                }
                else if (goalsScoredGroup.Count() == teams.Count)
                {
                    if (_successor != null)
                    {
                        var teamsInGroup = goalsScoredGroup.Select(x => x.TeamId).ToList();
                        calculatedTable.AddRange(_successor.Sort(resultsForTeams, teamsInGroup));
                    }
                }
                else
                {
                    var teamsInGroup = goalsScoredGroup.Select(x => x.TeamId).ToList();
                    calculatedTable.AddRange(new IIHFSorter().Sort(resultsForTeams, teamsInGroup));
                }
            }
            return calculatedTable;
        }
    }

    internal class IIHFSorter
    {

        public List<TableEntry> Sort(List<Result> results, List<int> teams)
        {
            var pointsSort = new SortByPoints();
            var goalDifferenceSort = new SortByGoalDifference();
            var goalsScoredSort = new SortByGoalsScored();
            pointsSort.SetSuccessor(goalDifferenceSort);
            goalDifferenceSort.SetSuccessor(goalsScoredSort);
            return pointsSort.Sort(results, teams);

        }
    }

}
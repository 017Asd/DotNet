using System;
using System.Collections.Generic;
using System.Linq;

public class Tournament
{
    private SortedList<int, Team> _rankings = new SortedList<int, Team>();
    private LinkedList<Match> _schedule = new LinkedList<Match>();
    private Stack<(Match match, int team1Points, int team2Points)> _undoStack =
        new Stack<(Match, int, int)>();

    public void ScheduleMatch(Match match)
    {
        _schedule.AddLast(match);
    }

    public void RecordMatchResult(Match match, int team1Score, int team2Score)
    {
        int prevPoints1 = match.Team1.Points;
        int prevPoints2 = match.Team2.Points;

        if (team1Score > team2Score)
            match.Team1.Points += 3;
        else if (team2Score > team1Score)
            match.Team2.Points += 3;
        else
        {
            match.Team1.Points += 1;
            match.Team2.Points += 1;
        }

        _undoStack.Push((match.Clone(), prevPoints1, prevPoints2));
        UpdateRankings(match.Team1);
        UpdateRankings(match.Team2);
    }

    private void UpdateRankings(Team team)
    {
        if (_rankings.ContainsValue(team))
        {
            int oldKey = _rankings.First(x => x.Value == team).Key;
            _rankings.Remove(oldKey);
        }

        while (_rankings.ContainsKey(team.Points))
            team.Points++;

        _rankings.Add(team.Points, team);
    }

    public void UndoLastMatch()
    {
        if (_undoStack.Count == 0)
            return;

        var entry = _undoStack.Pop();
        var match = entry.match;

        match.Team1.Points = entry.team1Points;
        match.Team2.Points = entry.team2Points;

        _rankings.Clear();
    }

    public int GetTeamRanking(Team team)
    {
        var ordered = _rankings.Values
            .OrderByDescending(t => t.Points)
            .ThenBy(t => t.Name)
            .ToList();

        return ordered.FindIndex(t => t == team) + 1;
    }

    public List<Team> GetRankings()
    {
        return _rankings.Values
            .OrderByDescending(t => t.Points)
            .ThenBy(t => t.Name)
            .ToList();
    }
}

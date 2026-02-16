public class Match
{
    public Team Team1 { get; }
    public Team Team2 { get; }

    public Match(Team team1, Team team2)
    {
        Team1 = team1;
        Team2 = team2;
    }

    public Match Clone()
    {
        return new Match(Team1, Team2);
    }
}

using System;

public class Team : IComparable<Team>
{
    public string Name { get; set; }
    public int Points { get; set; }

    public int CompareTo(Team other)
    {
        int pointCompare = other.Points.CompareTo(Points);
        if (pointCompare != 0)
            return pointCompare;

        return Name.CompareTo(other.Name);
    }
}

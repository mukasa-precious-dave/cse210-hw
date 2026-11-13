public class NegativeGoal : Goal
{
    public NegativeGoal(string name, string description, int points) : base(name, description, points)
    {
    }

    public override void RecordEvent()
    {
        // Points are deducted in GoalManager when recorded
    }

    public override bool IsComplete()
    {
        return false; // Bad habits are ongoing struggles
    }

    public override string GetDetailsString()
    {
        return $"[-] {_shortName} ({_description}) [Penalty: -{_points} pts]";
    }

    public override string GetStringRepresentation()
    {
        return $"NegativeGoal:{_shortName},{_description},{_points}";
    }
}
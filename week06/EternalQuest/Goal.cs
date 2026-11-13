public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }

    // Abstract methods that derived classes must implement
    public abstract void RecordEvent();
    public abstract bool IsComplete();

    // Virtual method with a default implementation, overridable if needed
    public virtual string GetDetailsString()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";
        return $"{checkbox} {_shortName} ({_description})";
    }

    // Abstract method to format the goal for saving to a file
    public abstract string GetStringRepresentation();

    // Getters for common attributes
    public string GetName() => _shortName;
    public string GetDescription() => _description;
    public int GetPoints() => _points;
}
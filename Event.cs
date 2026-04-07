class Event
{
    static int nextTurn = 1;

    public int TurnNumber { get; }

    public string Description { get; }

    public EventType Type { get; }

    public int Value { get; }

    Event(string description, EventType type, int value)
    {
        TurnNumber = nextTurn++;
        Description = description;
        Type = type;
        Value = value;
    }
}

enum EventType
{
    Attack,
    Heal,
    LevelUp,
    Loot,
    Skip
}
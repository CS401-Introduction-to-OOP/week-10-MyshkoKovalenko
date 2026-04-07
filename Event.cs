class Event
{
    static int nextTurn = 1;

    public int TurnNumber { get; }

    public string Description { get; }

    public EventType Type { get; }

    public int Value { get; }

    public Event(string description, EventType type, int value)
    {
        TurnNumber = nextTurn++;
        Description = description;
        Type = type;
        Value = value;
    }

    public override string ToString() => $"{TurnNumber} | {Description} | Type: {Type} | Value : {Value}";
}

enum EventType
{
    Damage,
    Heal,
    LevelUp,
    Loot,
    Skip
}
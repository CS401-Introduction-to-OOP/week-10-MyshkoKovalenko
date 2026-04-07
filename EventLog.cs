using System.Collections;

class EventLog : IEnumerable<Event>
{
    List<Event> _events;

    EventLog()
    {
        _events = new List<Event>();
    }

    public void AddEvent(Event newEvent)
    {
        _events.Add(newEvent);
    }

    public IEnumerator<Event> GetEnumerator()
    {
        foreach (Event e in _events)
            yield return e;
    }

    public IEnumerator<Event> GetEnumeratorOfType(EventType type)
    {
        foreach (Event e in _events)
        {
            if (e.Type == type)
                yield return e;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
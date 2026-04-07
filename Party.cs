using System.Collections;

class EventLog : IEnumerable<Character>
{
    List<Character> _characters;

    EventLog()
    {
        _characters = new List<Character>();
    }

    public void AddMember(Character newMember)
    {
        _characters.Add(newMember);
    }

    public IEnumerator<Character> GetEnumerator()
    {
        foreach (Character c in _characters)
            yield return c;
    }

    public IEnumerable<Character> GetAliveEnumerator()
    {
        foreach (Character c in _characters)
        {
            if (c.IsAlive)
                yield return c;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
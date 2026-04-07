using System.Collections;

class Party : IEnumerable<Character>
{
    List<Character> _characters;

    public Party()
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

    public IEnumerator<Character> GetAliveEnumerator()
    {
        foreach (Character c in _characters)
        {
            if (c.IsAlive)
                yield return c;
        }
    }

    public IEnumerator<Character> GetEnumeratorWhereCharactersHaveHigherLevelThan(int level) => _characters.Where<Character>(c => c.Level >= level).GetEnumerator();

    public IEnumerator<Character> GetEnumeratorOrderedByHP() => _characters.OrderBy(c => c.HP).GetEnumerator();

    public IEnumerator<string> GetEnumeratorOfNames() => _characters.Select(c => c.Name).GetEnumerator();

    public Character GetMaxLevelCharacter() => _characters.MaxBy(c => c.Level);

    public IEnumerator<IGrouping<Role, Character>> GroupByRole() => _characters.GroupBy(c => c.Role).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
using System.Formats.Asn1;

Random rnd = new Random();

Party myParty = new Party();
EventLog myLog = new EventLog();

string userInput;
string[] userTokens;

const string EXITCODE = "q";
do
{
    Console.Write("$ ");
    userInput = Console.ReadLine();

    try
    {
        userTokens = userInput.Split();

        if (userTokens[0] == "h")
            printHelp();
        else if (userTokens[0] == "cc")
            createCharacter();
        else if (userTokens[0] == "d")
            damageRandom();
        else if (userTokens[0] == "h")
            healRandom();
        else if (userTokens[0] == "g")
            giveRandomGold();
        else if (userTokens[0] == "llp")
            levelUpRandom();
        else if (userTokens[0] == "s")
            skipTurn();
        else if (userTokens[0] == "el")
            eventLogPrint();
        else if (userTokens[0] == "p")
            partyPrint();
        else if (userTokens[0] == EXITCODE)
            Console.WriteLine("Goodbye.");
        else
            throw new Exception();
    }
    catch
    {
        Console.WriteLine("Invalid input. Type 'h' for help.");
    }


} while (userInput != EXITCODE);

void printHelp()
{
    Console.WriteLine("h - help\ncc [name] [role] - create character\nd - damage random character\nh - heal random character\ng - give random character gold\nllp - level random character up\ns - skip turn\nel [type] - show event log (opt. filter by particular type)\np [-a](alive) [-h <level>](higher than level) [-o](ordered by hp) [-n](names) [-m](max hp) [-r](grouped by role)\nq - quit");
}

void createCharacter()
{
    myParty.AddMember(new Character(userTokens[1], (Role)Enum.Parse(typeof(Role), userTokens[2])));
}

void damageRandom()
{
    IEnumerator<Character> en = myParty.GetAliveEnumerator();

    while (en.MoveNext())
        en.Current.Damage(rnd.Next() % 20);
}

void healRandom()
{
    IEnumerator<Character> en = myParty.GetAliveEnumerator();

    while (en.MoveNext())
        en.Current.Heal(rnd.Next() % 20);
}

void giveRandomGold()
{
    IEnumerator<Character> en = myParty.GetAliveEnumerator();

    while (en.MoveNext())
        en.Current.Loot(rnd.Next() % 20);
}

void levelUpRandom()
{
    IEnumerator<Character> en = myParty.GetAliveEnumerator();

    while (en.MoveNext())
        en.Current.LevelUp(rnd.Next() % 10);
}

void skipTurn()
{
    myLog.AddEvent(new Event("The turn has been skipped.", EventType.Skip, 0));
}

void eventLogPrint()
{
    IEnumerator<Event> en;

    if (userTokens.Length == 2)
        en = myLog.GetEnumeratorOfType((EventType)Enum.Parse(typeof(EventType), userTokens[1]));
    else
        en = myLog.GetEnumerator();
    
    while (en.MoveNext())
        Console.WriteLine(en.Current);
}

void partyPrint()
{
    IEnumerator<Character> en;
    IEnumerator<string> stren;
    Character character;
    IEnumerator<IGrouping<Role, Character>> gr;

    if (userTokens.Length == 1)
    {
        foreach(Character c in myParty)
        {
            Console.WriteLine(c);
        }
    }
    else if (userTokens[1] == "-a")
    {
        en = myParty.GetAliveEnumerator();
        while (en.MoveNext())
            Console.WriteLine(en.Current);
    }
    else if (userTokens[1] == "-h")
    {
        en = myParty.GetEnumeratorWhereCharactersHaveHigherLevelThan(int.Parse(userTokens[2]));
        while (en.MoveNext())
            Console.WriteLine(en.Current);
    }
    else if (userTokens[1] == "-o")
    {
        en = myParty.GetEnumeratorOrderedByHP();
        while (en.MoveNext())
            Console.WriteLine(en.Current);
    }
    else if (userTokens[1] == "-n")
    {
        stren = myParty.GetEnumeratorOfNames();
        while (stren.MoveNext())
            Console.WriteLine(stren.Current);
    }
    else if (userTokens[1] == "-m")
    {
        character = myParty.GetMaxLevelCharacter();
        Console.WriteLine(character);
    }
    else if (userTokens[1] == "-r")
    {
        gr = myParty.GroupByRole();
        while (gr.MoveNext())
        {
            Console.WriteLine($"{gr.Current.Key}:\n");
            foreach (Character c in gr.Current)
                Console.WriteLine($"- {c}");
        }
    }
}
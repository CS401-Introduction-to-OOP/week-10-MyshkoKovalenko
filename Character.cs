class Character
{
    public string Name { get; }

    public Role Role { get; }

    public int Level { get; }

    public int HP { get; }

    public int Gold { get; }

    public bool IsAlive { get => HP > 0; }

    public Character(string name, Role role)
    {
        Name = name;
        Role = role;
        Level = 1;
        HP = 100;
        Gold = 0;
    } 
}

enum Role
{
    Warrior,
    Archer,
    Wizard
}
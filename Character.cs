class Character
{
    public string Name { get; }

    public Role Role { get; }

    public int Level { get; private set; }

    public int HP { get; private set;}

    public int Gold { get; private set; }

    public bool IsAlive { get => HP > 0; }

    public Character(string name, Role role)
    {
        Name = name;
        Role = role;
        Level = 1;
        HP = 100;
        Gold = 0;
    }

    public void Damage(int value)
    {
        HP -= value;
    }

    public void Heal(int value)
    {
        HP += value;
    }

    public void Loot(int value)
    {
        Gold += value;
    }

    public void LevelUp(int value)
    {
        Level += value;
    }

    public override string ToString() => $"{Name} | {Level} LVL | {HP} HP | {Gold} Gold | Alive: {(IsAlive ? "YES" : "NO")}";
}

enum Role
{
    Warrior,
    Archer,
    Wizard
}
Party DiddyParty = new Party();
DiddyParty.AddMember(new Character("John Pork", Role.Warrior));
DiddyParty.AddMember(new Character("Tim Cheese", Role.Archer));
DiddyParty.AddMember(new Character("Jeff", Role.Wizard));

IEnumerator<Character> cenum = DiddyParty.GetEnumerator();

while (cenum.MoveNext())
{
    Console.WriteLine(cenum.Current.Name);
}
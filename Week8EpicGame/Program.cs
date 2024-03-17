using System.ComponentModel.Design;

string folderPath = @"C:\Users\roosm\OneDrive\Desktop\data\";
string heroFile = "heroes.txt";
string villainFile = "villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));


string[] weapon = { "magic wand", "wooden sword", "glass slipper", "lego brick", "wooden stick" };


string hero = GetRandomValueFromArray(heroes);
string heroWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero);
int heroStrikeStrenght = heroHP;
Console.WriteLine($"Today {hero} ({heroHP} HP saves the day with {heroWeapon}");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrenght = villainHP;
Console.WriteLine($"Today {villain} ({villainHP} HP tries to take over the world with {villainWeapon}!");


while (heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainHP);
    villainHP = villainHP - Hit(hero, heroHP);
}
Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saves the world!");

}
else if (villainHP > 0)
{
    Console.WriteLine($"{villain} dark side wins!");
}
else
{
    Console.WriteLine("Nobody won!");
}





static string GetRandomValueFromArray(string[] someArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, someArray.Length);
    string randomStringFromArray = someArray[randomIndex];
    return randomStringFromArray;
}


static int GetCharacterHP(string characterName)
{
    if (characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);
    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterHP} made a critical hit!");

    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }
    return strike;
}

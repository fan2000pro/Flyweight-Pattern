using System;
using System.Collections.Generic;

public class Character
{
    public string Name { get; }
    public string Type { get; }
    public string Image { get; }

    public int Level { get; set; }
    public int Experience { get; set; }

    private Character(string name, string type, string image)
    {
        Name = name;
        Type = type;
        Image = image;
    }

    public override string ToString()
    {
        return $"Character: {Name}, Type: {Type}, Image: {Image}, Level: {Level}, Experience: {Experience}";
    }

    public static class CharacterFactory
    {
        private static readonly Dictionary<string, Character> _characters = new();

        public static Character GetCharacter(string name, string type, string image)
        {
            string key = $"{name}_{type}";
            if (_characters.ContainsKey(key))
            {
                return _characters[key];
            }

            var character = new Character(name, type, image);
            _characters[key] = character;
            return character;
        }

        public static void PrintAllCharacters()
        {
            Console.WriteLine("Existing Characters in Factory:");
            foreach (var character in _characters.Values)
            {
                Console.WriteLine($"- {character.Name} ({character.Type})");
            }
        }
    }
}

public class Program
{
    public static void Main()
    {
        var warrior = Character.CharacterFactory.GetCharacter("Arthur", "Warrior", "warrior.png");
        warrior.Level = 10;
        warrior.Experience = 1500;

        var mage = Character.CharacterFactory.GetCharacter("Merlin", "Mage", "mage.png");
        mage.Level = 150;
        mage.Experience = 2300;

        var warriorClone = Character.CharacterFactory.GetCharacter("Arthur", "Warrior", "warrior.png");
        warriorClone.Level = 1200;

        Console.WriteLine(warrior);
        Console.WriteLine(mage);
        Console.WriteLine(warriorClone);

        Character.CharacterFactory.PrintAllCharacters();
    }
}

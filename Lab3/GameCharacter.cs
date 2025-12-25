using System;

public class GameCharacter
{
    private string name;
    private int level;
    private int health;
    private CharacterClass characterClass;

    public int MaxHealth { get; private set; } = 100;

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length < 3 || value.Length > 12)
                throw new Exception("Ім'я має містити 3–12 символів.");
            name = value;
        }
    }

    public int Level
    {
        get => level;
        private set
        {
            if (value < 1 || value > 100)
                throw new Exception("Рівень має бути від 1 до 100.");
            level = value;
        }
    }

    public int Health
    {
        get => health;
        set
        {
            if (value < 0 || value > MaxHealth)
                throw new Exception("Здоров'я має бути в межах 0–100.");
            health = value;
        }
    }

    public CharacterClass CharacterClass
    {
        get => characterClass;
        set
        {
            if (!Enum.IsDefined(typeof(CharacterClass), value))
                throw new Exception("Некоректний клас персонажа.");
            characterClass = value;
        }
    }

    public bool IsAlive => Health > 0;
    public GameCharacter() : this("Unknown", CharacterClass.Warrior)
    {
        Console.WriteLine("Викликано конструктор: GameCharacter()");
    }
    public GameCharacter(string name, CharacterClass characterClass) : this(name, characterClass, 1, 100)
    {
        Console.WriteLine("Викликано конструктор: GameCharacter(string, CharacterClass)");
    }

    public GameCharacter(string name, CharacterClass characterClass, int level, int health)
    {
        Console.WriteLine("Викликано конструктор: GameCharacter(string, CharacterClass, int, int)");

        Name = name;
        CharacterClass = characterClass;
        Level = level;
        Health = health;
    }

    private void CheckAlive()
    {
        if (!IsAlive)
            throw new Exception("Персонаж мертвий.");
    }

    public void Attack()
    {
        CheckAlive();
        Console.WriteLine($"{Name} атакує без зброї!");
    }

    public void Attack(int power)
    {
        CheckAlive();
        Console.WriteLine($"{Name} атакує з силою {power}!");
    }

    public void Attack(string skill)
    {
        CheckAlive();
        Console.WriteLine($"{Name} використовує здібність: {skill}");
    }

    public void TakeDamage(int damage)
    {
        if (damage < 0)
            throw new Exception("Шкода не може бути від'ємною.");
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public string GetInfo()
    {
        return $"{Name,-12} | {CharacterClass,-8} | {Level,3} | {Health,3} | {(IsAlive ? "Alive" : "Dead")}";
    }
}

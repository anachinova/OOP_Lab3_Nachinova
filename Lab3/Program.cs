using System;
using System.Collections.Generic;
using System.Text;

class Program
{
    static List<GameCharacter> characters = new List<GameCharacter>();
    static int maxCount;

    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        Console.Write("Введіть N (максимальна кількість об'єктів): ");
        while (!int.TryParse(Console.ReadLine(), out maxCount) || maxCount <= 0)
            Console.Write("Помилка! Введіть коректне N: ");

        while (true)
        {
            Console.WriteLine("\n1 – Додати об'єкт");
            Console.WriteLine("2 – Переглянути всі об'єкти");
            Console.WriteLine("3 – Знайти об'єкт");
            Console.WriteLine("4 – Продемонструвати поведінку");
            Console.WriteLine("5 – Видалити об'єкт");
            Console.WriteLine("0 – Вийти");

            Console.Write("Ваш вибір: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": AddCharacter(); break;
                case "2": ShowAll(); break;
                case "3": FindCharacter(); break;
                case "4": DemonstrateBehavior(); break;
                case "5": DeleteCharacter(); break;
                case "0":
                    Console.WriteLine("Програму завершено.");
                    return;
                default:
                    Console.WriteLine("Невірний пункт меню.");
                    break;
            }
        }
    }

    static void AddCharacter()
    {
        if (characters.Count >= maxCount)
        {
            Console.WriteLine("Досягнуто ліміту об'єктів.");
            return;
        }

        Console.WriteLine("Оберіть конструктор:");
        Console.WriteLine("1 – Без параметрів");
        Console.WriteLine("2 – Ім'я + клас");
        Console.WriteLine("3 – Усі параметри");

        string option = Console.ReadLine();
        GameCharacter c;

        try
        {
            switch (option)
            {
                case "1":
                    c = new GameCharacter();
                    break;

                case "2":
                    Console.Write("Ім'я: ");
                    string name = Console.ReadLine();

                    Console.Write("Клас (0–3): ");
                    CharacterClass cls = (CharacterClass)int.Parse(Console.ReadLine());

                    c = new GameCharacter(name, cls);
                    break;

                case "3":
                    Console.Write("Ім'я: ");
                    string n = Console.ReadLine();

                    Console.Write("Клас (0–3): ");
                    CharacterClass ccls = (CharacterClass)int.Parse(Console.ReadLine());

                    Console.Write("Рівень: ");
                    int lvl = int.Parse(Console.ReadLine());

                    Console.Write("Здоров'я: ");
                    int hp = int.Parse(Console.ReadLine());

                    c = new GameCharacter(n, ccls, lvl, hp);
                    break;

                default:
                    Console.WriteLine("Невірний вибір.");
                    return;
            }

            characters.Add(c);
            Console.WriteLine("Об'єкт додано.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void ShowAll()
    {
        if (characters.Count == 0)
        {
            Console.WriteLine("Список порожній.");
            return;
        }

        Console.WriteLine("Ім'я         | Клас     | Lvl | HP  | Стан");
        Console.WriteLine("-------------------------------------------");
        foreach (var c in characters)
            Console.WriteLine(c.GetInfo());
    }

    static void FindCharacter()
    {
        Console.Write("Введіть ім'я: ");
        string name = Console.ReadLine();

        foreach (var c in characters)
            if (c.Name == name)
                Console.WriteLine(c.GetInfo());
    }

    static void DemonstrateBehavior()
    {
        if (characters.Count == 0)
        {
            Console.WriteLine("Немає об'єктів.");
            return;
        }

        GameCharacter c = characters[0];

        c.Attack();
        c.Attack(50);
        c.Attack("Вогняний удар");
    }

    static void DeleteCharacter()
    {
        Console.Write("Ім'я для видалення: ");
        string name = Console.ReadLine();

        characters.RemoveAll(c => c.Name == name);
        Console.WriteLine("Видалення виконано.");
    }
}

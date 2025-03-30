using System;
using System.Collections.Generic;

// 1. Фигуры
public abstract class Shape
{
    public abstract double GetArea();
    public abstract double GetPerimeter();
}

public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public override double GetArea() => Width * Height;
    public override double GetPerimeter() => 2 * (Width + Height);
}

public class Circle : Shape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public override double GetArea() => Math.PI * Radius * Radius;
    public override double GetPerimeter() => 2 * Math.PI * Radius;
}

// 2. Животные
public abstract class Animal
{
    public string Name { get; set; }
    public abstract void MakeSound();
}

public class Dog : Animal
{
    public override void MakeSound() => Console.WriteLine("Гав-гав");
}

public class Cat : Animal
{
    public override void MakeSound() => Console.WriteLine("Мяу-мяу");
}

public class Cow : Animal
{
    public override void MakeSound() => Console.WriteLine("Муу");
}

// 3. Транспорт
public abstract class Transport
{
    public double Speed { get; set; }
    public abstract void Move();
}

public class Car : Transport
{
    public override void Move() => Console.WriteLine($"Еду по дороге со скоростью {Speed} км/ч");
}

public class Boat : Transport
{
    public override void Move() => Console.WriteLine($"Плыву по воде со скоростью {Speed} км/ч");
}

public class Plane : Transport
{
    public override void Move() => Console.WriteLine($"Лечу в небе со скоростью {Speed} км/ч");
}

// 4. Банк
public abstract class BankAccount
{
    public double Balance { get; set; }
    public abstract void Withdraw(double amount);
    public void Deposit(double amount) => Balance += amount;
}

public class SavingsAccount : BankAccount
{
    public override void Withdraw(double amount)
    {
        if (Balance - amount >= 100)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Недостаточно средств");
        }
    }
}

public class CreditAccount : BankAccount
{
    public override void Withdraw(double amount)
    {
        if (Balance - amount >= -500)
        {
            Balance -= amount;
        }
        else
        {
            Console.WriteLine("Превышен лимит");
        }
    }
}

// 5. Игровые персонажи
public abstract class GameCharacter
{
    public string Name { get; set; }
    public abstract void Attack();
}

public class Warrior : GameCharacter
{
    public override void Attack() => Console.WriteLine($"{Name} атакует мечом!");
}

public class Mage : GameCharacter
{
    public override void Attack() => Console.WriteLine($"{Name} атакует магией!");
}

public class Archer : GameCharacter
{
    public override void Attack() => Console.WriteLine($"{Name} стреляет из лука!");
}

// 6. Роботы
public abstract class Robot
{
    public string Model { get; set; }
    public abstract void PerformTask();
}

public class CleanerRobot : Robot
{
    public override void PerformTask() => Console.WriteLine($"{Model} убирает комнату");
}

public class CookRobot : Robot
{
    public override void PerformTask() => Console.WriteLine($"{Model} готовит еду");
}

public class GuardRobot : Robot
{
    public override void PerformTask() => Console.WriteLine($"{Model} охраняет помещение");
}

public class Program
{
    public static void Main(string[] args)
    {
        // 1. Фигуры
        Shape[] shapes = new Shape[]
        {
            new Rectangle(5, 10),
            new Rectangle(3, 7),
            new Circle(4),
            new Circle(2),
            new Circle(6)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Площадь: {shape.GetArea()}, Периметр: {shape.GetPerimeter()}");
        }

        // 2. Животные
        List<Animal> animals = new List<Animal>
        {
            new Dog { Name = "Бобик" },
            new Cat { Name = "Мурка" },
            new Cow { Name = "Бурёнка" }
        };

        foreach (var animal in animals)
        {
            animal.MakeSound();
        }

        // 3. Транспорт
        Transport[] transports = new Transport[]
        {
            new Car { Speed = 100 },
            new Boat { Speed = 30 },
            new Plane { Speed = 800 }
        };

        foreach (var transport in transports)
        {
            transport.Move();
        }

        // 4. Банк
        SavingsAccount savingsAccount = new SavingsAccount { Balance = 500 };
        CreditAccount creditAccount = new CreditAccount { Balance = 100 };

        savingsAccount.Withdraw(200);
        Console.WriteLine($"Savings Balance: {savingsAccount.Balance}");
        savingsAccount.Withdraw(450);
        Console.WriteLine($"Savings Balance: {savingsAccount.Balance}");
        savingsAccount.Deposit(100);
        Console.WriteLine($"Savings Balance: {savingsAccount.Balance}");

        creditAccount.Withdraw(300);
        Console.WriteLine($"Credit Balance: {creditAccount.Balance}");
        creditAccount.Withdraw(300);
        Console.WriteLine($"Credit Balance: {creditAccount.Balance}");
        creditAccount.Deposit(100);
        Console.WriteLine($"Credit Balance: {creditAccount.Balance}");

        // 5. Игровые персонажи
        GameCharacter[] characters = new GameCharacter[]
        {
            new Warrior { Name = "Артур" },
            new Mage { Name = "Мерлин" },
            new Archer { Name = "Робин" }
        };

        foreach (var character in characters)
        {
            character.Attack();
        }

        // 6. Роботы
        Robot[] robots = new Robot[]
        {
            new CleanerRobot { Model = "Пылесос" },
            new CookRobot { Model = "Кухонный комбайн" },
            new GuardRobot { Model = "Охранник" }
        };

        foreach (var robot in robots)
        {
            robot.PerformTask();
        }
    }
}

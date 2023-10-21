
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

public static class GlobalPos
{
    public static int GlobalPosition;
    public static int TotalPrice;
    public static List<Podpunkt> Order = new List<Podpunkt> {};
}



public class Zakaz
{
    public static void Strelochki(int Size)
    {
        var position = 3;
        if (GlobalPos.GlobalPosition == 1) 
        {
            Size = MenuText.MenuTextPos1().Count();
            Menu.Menu1(MenuText.MenuTextPos1());
        }
        else if (GlobalPos.GlobalPosition != 1)
        {
            Size = MenuText.MenuTextPos2().Count();
            Menu.Menu2(MenuText.MenuTextPos2());
        }
        while (true)
        {
            ConsoleKeyInfo UserButton;
            Console.SetCursorPosition(0, position);
            Console.WriteLine("->");
            UserButton = Console.ReadKey(true);
            Console.SetCursorPosition(0, position);
            Console.WriteLine("  ");
            if (UserButton.Key == ConsoleKey.Escape)
            {
                GlobalPos.GlobalPosition = 1;
                Console.Clear();
                Strelochki(5);
            }
            else if (UserButton.Key == ConsoleKey.DownArrow & position != Size + 2)
            {
                position++;
            }
            else if (UserButton.Key == ConsoleKey.UpArrow & position != 3)
            {
                position--;
            }
            else if (UserButton.Key == ConsoleKey.Enter)
            {
                if (GlobalPos.GlobalPosition == 1)
                {
                    GlobalPos.GlobalPosition = position-1;
                    Console.Clear();
                    Strelochki(1);
                }
                else
                {
                    Podpunkt choice = new Podpunkt (N: MenuText.MenuTextPos2()[position - 3].Name,  C: MenuText.MenuTextPos2()[position - 3].Cost);
                    GlobalPos.Order.Add(choice);
                    GlobalPos.TotalPrice += MenuText.MenuTextPos2()[position-3].Cost;
                    Console.Clear();
                    Strelochki(1);
                }
            }

        }
    }
}

public class MenuText
{
    public static List<string> MenuTextPos1()
    {
        if (GlobalPos.GlobalPosition == 1)
        {
            List<string> Pos1 = new List<string>();
            {
                Pos1.Add("  Форма торта");
                Pos1.Add("  Размер торта");
                Pos1.Add("  Вкус коржей");
                Pos1.Add("  Количество коржей");
                Pos1.Add("  Глязурь");
                Pos1.Add("  Декор");
                Pos1.Add("  Конец заказа");
            }
            return Pos1;
        }
        else
        {
            return new List<string>();
        }
    }

    public static List<Podpunkt> MenuTextPos2()
    {
        if (GlobalPos.GlobalPosition == 2)
        {
            List<Podpunkt> Pos2 = new List<Podpunkt>()
            {
                new Podpunkt("  Круг - ", 100),
                new Podpunkt("  Кватрат - ", 200),
                new Podpunkt("  Треугольник - ", 300),
                new Podpunkt("  Прямоугольник - ", 400),
            };
            return Pos2;
        }
        else if (GlobalPos.GlobalPosition == 3)
        {
            List<Podpunkt> Pos3 = new List<Podpunkt>()
            {
                new Podpunkt(N: "  Маленький (15 см в диаметре) - ", C: 300),
                new Podpunkt(N: "  Средний (25 см в диаметре) - ", C: 500),
                new Podpunkt(N: "  Большой (35 см в диаметре) - ", C: 700),
            };
            return Pos3;
        }
        else if (GlobalPos.GlobalPosition == 4)
        {
            List<Podpunkt> Pos4 = new List<Podpunkt>()
            {
                new Podpunkt(N: "  Банановый корж - ", C: 50),
                new Podpunkt(N: "  Ванильный корж- ", C: 60),
                new Podpunkt(N: "  Шоколадный корж - ", C: 60),
            };
            return Pos4;
        }
        else if (GlobalPos.GlobalPosition == 5)
        {
            List<Podpunkt> Pos5 = new List<Podpunkt>()
            {
                new Podpunkt(N: "  Два коржа - ", C: 200),
                new Podpunkt(N: "  Четыре коржа - ", C: 400),
                new Podpunkt(N: "  Шесть коржей - ", C: 600),
            };
            return Pos5;
        }
        else if (GlobalPos.GlobalPosition == 6)
        {
            List<Podpunkt> Pos6 = new List<Podpunkt>()
            {
                new Podpunkt(N: "  Молочная глазурь - ", C: 50),
                new Podpunkt(N: "  Шоколадная глазурь - ", C: 60),
                new Podpunkt(N: "  Сахарная глазурь - ", C: 20),
            };
            return Pos6;
        }
        else if (GlobalPos.GlobalPosition == 7)
        {
            List<Podpunkt> Pos7 = new List<Podpunkt>()
            {
                new Podpunkt(N: "  Вафли - ", C: 100),
                new Podpunkt(N: "  Фруккты и ягоды - ", C: 150),
                new Podpunkt(N: "  Съедобная картинка - ", C: 300),
            };
            return Pos7;
        }
        else
        {
            Zapis();
            Finish();
            return null;
        }
    }
    private static void Finish()
    {
        GlobalPos.TotalPrice = 0;
        GlobalPos.Order.Clear();
        Console.Clear();
        Console.WriteLine("Спасибо за заказ. Чтобы оформить еще один - нажмите Escape");
        ConsoleKeyInfo UserButton;
        UserButton = Console.ReadKey();
        if (UserButton.Key == ConsoleKey.Escape)
        {
            Console.Clear() ;   
            Program.Main();
        }
        else
        {
            Environment.Exit(0);
        }
    }
    private static void Zapis()
    {
        var Summa = GlobalPos.TotalPrice;
        var a = Summa.ToString();
        DateTime dateTime = DateTime.Now;
        string x = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop)+ "\\FileZakaz.txt");
        if (File.Exists(x))
        {
            string txt = File.ReadAllText(x);
        }
        else
        {
            File.Create(x).Close();
        }
        File.AppendAllText(x, "\n Дата: " + dateTime.ToString());
        File.AppendAllText(x, "\n Чек заказа: ");
        for (int i = 0; i < GlobalPos.Order.Count(); i++)
        {
            File.AppendAllText(x, GlobalPos.Order[i].Name + GlobalPos.Order[i].Cost + ",");
        }
        File.AppendAllText(x, "\n Цена заказа: " + a);
        File.AppendAllText(x, "\n ");
    }
}
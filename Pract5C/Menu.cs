using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;


static public class Menu
{
    public static void Menu1(List<string> values)
    {
        Console.WriteLine("Заказ в кондитерской Шоколандный Заяц");
        Console.WriteLine("Выберите параметры торта");
        Console.WriteLine("--------------------------------");
        foreach (string MenuStr in values)
        {
            Console.WriteLine("  " + MenuStr);
        }
        Propusk();
        Console.WriteLine("Цена заказа - " + GlobalPos.TotalPrice);
        Console.Write("Чек заказа: ");
        for (int i = 0; i < GlobalPos.Order.Count; i++)
        {
            Console.Write(GlobalPos.Order[i].Name + " " + GlobalPos.Order[i].Cost + ",");
        }
    }
    public static void Menu2(List<Podpunkt> values)
    {
        Console.WriteLine("Заказ в кондитерской Шоколандный Заяц");
        Console.WriteLine("Выберите параметры торта");
        Console.WriteLine("--------------------------------");
        foreach (Podpunkt MenuStr in values)
        {
            Console.WriteLine(MenuStr.Name + " " + MenuStr.Cost);
        }
        Propusk();
        Console.WriteLine("Цена заказа - " + GlobalPos.TotalPrice);
        Console.Write("Чек заказа: ");
        for (int i = 0; i < GlobalPos.Order.Count; i++)
        {
            Console.Write(GlobalPos.Order[i].Name + " " + GlobalPos.Order[i].Cost+ ",");
        }
    }
    private static void Propusk()
    {
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine(" ");
        }
    }
}



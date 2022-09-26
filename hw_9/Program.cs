using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Console;


namespace hw_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Меню:\n" +
                    "1. Распечатать парк автомобилей;\n" +
                    "2. Отсортировать парк по марке;\n" +
                    "3. Отсортировать парк по стоимости;\n" +
                    "4. Отсортировать парк по типу;\n" +
                    "5. Отсортировать парк по модели;\n" +
                    "6. Копирование и смена марки у копии;\n" +
                    "7. Выйти из программы.\n\n");
            while (true)
            {
                WriteLine("Какое действие хотите произвести:\n");
                int pos = int.Parse(ReadLine());
                switch (pos)
                {
                    case 1:
                        {
                            WriteLine("*****Парк автомобилей*****");
                            AutoPas parks = new AutoPas();
                            foreach(Ground item in parks)
                            {
                                WriteLine(item);
                            }
                            WriteLine();
                        }
                        break;

                    case 2:
                        {
                            WriteLine("*****Отсортированный парк автомобилей по марке*****");
                            AutoPas parks = new AutoPas();
                            parks.Sort();
                            foreach (Ground item in parks)
                            {
                                WriteLine(item);
                            }
                            WriteLine();
                        }
                        break;

                    case 3:
                        {
                            WriteLine("*****Отсортированный парк автомобилей по стоимости*****");
                            AutoPas parks = new AutoPas();
                            parks.Sort(new SortCost());
                            foreach (Ground item in parks)
                            {
                                WriteLine(item);
                            }
                            WriteLine();

                        }
                        break;

                    case 4:
                        {
                            {
                                WriteLine("*****Отсортированный парк автомобилей по типу*****");
                                AutoPas parks = new AutoPas();
                                parks.Sort(new SortType());
                                foreach (Ground item in parks)
                                {
                                    WriteLine(item);
                                }
                                WriteLine();

                            }

                        }
                        break;

                    case 5:
                        {
                            WriteLine("*****Отсортированный парк автомобилей по модели*****");
                            AutoPas parks = new AutoPas();
                            parks.Sort(new SortModel());
                            foreach (Ground item in parks)
                            {
                                WriteLine(item);
                            }
                            WriteLine();

                        }
                        break;

                    case 6:
                        {
                            WriteLine("*****Копирование*****");
                            Passenger p1 = new Passenger { Stamp = "Volvo", Model = "XC90", Cost = 4100000, Type = "Кроссовер", PassengerNumbers = 5 };
                            WriteLine($"p1: {p1}");
                            WriteLine("Копируем p1 в p2:");
                            Passenger p2 = (Passenger)p1.Clone();
                            WriteLine($"p2: {p2}");
                            WriteLine("Заменим марку у p2 на введеное вами значение.\n Введите марку: ");
                            p2.Stamp = ReadLine();
                            WriteLine($"p1: {p1}");
                            WriteLine($"p2: {p2}");
                        }
                        break;

                   case 7:
                        return;

                    default:
                        WriteLine("Вы выбрали несуществующий пункт меню. Выберите снова.");
                        continue;
                }
            }
        }
    }
}

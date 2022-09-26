using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Reflection;

namespace hw_9
{
    abstract class TC
    {
        public string Stamp { get; set; }
        public string Model { get; set; }
        public int Cost { get; set; }
        public override string ToString()
        {
            return $"\nМарка: {Stamp} Модель: {Model} Стоимость: {Cost} руб.";
        }
    }

    abstract class Ground : TC, IComparable, ICloneable
    {
        public string Type { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" Тип: {Type}";
        }
        public object Clone() 
        {
            Ground tmp = (Ground)this.MemberwiseClone(); //поверхностная копия объекта, только не для ссылочных параметров    
            return tmp;
        }

        public int CompareTo(object obj)
        {
            if (obj is Ground)
            {
                return Stamp.CompareTo((obj as Ground).Stamp);
            }
            throw new NotImplementedException();
        }
    }
    abstract class Air : TC
    {
        public int NumberEngines { get; set; }
        public override string ToString()
        {
            return base.ToString() + $" Вид: {NumberEngines}";
        }
    }

    interface IFunctions
    {
        string IsWork();
        string Work();
        string Transfer();
    }

    interface IPark
    {
        List<IFunctions> park { get; set; }
        int Costs();
    }

    class Passenger : Ground, IFunctions
    {
        public int PassengerNumbers { get; set; }
        public string IsWork()
        {
            return "Наземный транспорт";
        }

        public string Transfer()
        {
            return "Перевожу пассажиров. ";
        }
        public string Work()
        {
            return "Легковой. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Количество пассажиров: {PassengerNumbers} чел.";
        }
    }

    class Cargo : Ground, IFunctions
    {
        public int Capacity { get; set; }
        public string IsWork()
        {
            return "Наземный транспорт";
        }
        public string Transfer()
        {
            return "Перевожу грузы. ";
        }
        public string Work()
        {
            return "Грузовой. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Грузоподъемность: {Capacity} т";
        }

    }

    class Moto : Ground, IFunctions
    {
        public int Power { get; set; }

        public string IsWork()
        {
            return "Наземный транспорт";
        }

        public string Transfer()
        {
            return "Катаю по красивым местам. ";
        }
        public string Work()
        {
            return "Мотоцикл. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Мощность: {Power} л.с.";
        }
    }

    class Plane : Air, IFunctions
    {
        public int Distance { get; set; }
        public string IsWork()
        {
            return "Воздушный транспорт";
        }

        public string Transfer()
        {
            return "Перевожу пассажиров на другие континенты. ";
        }
        public string Work()
        {
            return "Самолет. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Дальность: {Distance} км";
        }

    }

    class Helicopter : Air, IFunctions
    {
        public int NumberScrews { get; set; }
        public string IsWork()
        {
            return "Воздушный транспорт";
        }

        public string Transfer()
        {
            return "Перевожу грузы на другие континенты. ";
        }
        public string Work()
        {
            return "Вертолет. ";
        }

        public override string ToString()
        {
            return base.ToString() + $" Количество несущих винтов: {NumberScrews}";
        }
    }

    class Airship : Air, IFunctions
    {
        public string FillingGas { get; set; }
        public string IsWork()
        {
            return "Воздушный транспорт";
        }

        public string Transfer()
        {
            return "Несу рекламу на борту. ";
        }
        public string Work()
        {
            return "Дирижабль. ";
        }
        public override string ToString()
        {
            return base.ToString() + $" Заполняющий газ: {FillingGas}";
        }
    }

    class Park : TC, IPark
    {
        public List<IFunctions> park { get; set; }

        int IPark.Costs()
        {
            int sum = 0;
            foreach (TC item in park)
            {
                sum += item.Cost;
            }
            return sum;
        }
    }

    class AutoPas : IEnumerable
    {
        Ground[] parks =
        {
            new Passenger { Stamp = "Volvo", Model = "XC90", Cost = 4100000, Type = "Кроссовер", PassengerNumbers = 5 },
            new Passenger { Stamp = "KIA", Model = "Optima", Cost = 3500000, Type = "Седан", PassengerNumbers = 5 },
            new Passenger { Stamp = "Audi", Model = "TT", Cost = 5300000, Type = "Спорткар", PassengerNumbers = 2 },
            new Cargo { Stamp = "Hyundai", Model = "HD78", Cost = 990000000, Type = "Рефрижиратор", Capacity = 5 },
            new Cargo { Stamp = "MAZ", Model = "TF45", Cost = 875000000, Type = "Самосвал", Capacity = 10 },
            new Cargo { Stamp = "Hyundai", Model = "HD79", Cost = 923000000, Type = "Фургон", Capacity = 6 }
        };
        public AutoPas() { }
        public AutoPas(int size)
        {
            parks = new Ground[size];
        }
        public int Length { get { return parks.Length; } }
        public Ground this[int index]
        {
            get
            {
                if (index >= 0 && index < parks.Length)
                {
                    return parks[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                parks[index] = value;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return parks.GetEnumerator();
        }
  
        public void Sort(IComparer comparer)
        {
            Array.Sort(parks, comparer);
        }
        public void Sort()
        {
            Array.Sort(parks);
        }

    }

    class SortCost : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Ground && y is Ground)
            {
                return (x as Ground).Cost > (y as Ground).Cost ? 1 : (x as Ground).Cost < (y as Ground).Cost ? -1 : 0;
            }
            throw new NotImplementedException();
        }
    }

    class SortType : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Ground && y is Ground)
            {
                return string.Compare((x as Ground).Type, (y as Ground).Type);
            }
            throw new NotImplementedException();
        }

    }

    class SortModel : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Ground && y is Ground)
            {
                return string.Compare((x as Ground).Model, (y as Ground).Model);
            }
            throw new NotImplementedException();
        }

    }
}


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScottFunWithLINQ
{
    class Program
    {
        //PASSING LINQ QUERIES FROM METHODS

        static void Main(string[] args)
        {
            IEnumerable<string> names = LINQoverList();

            foreach (string item in names)
            {
                Console.WriteLine("LIST<T> PetName: " + item);
            }

            Console.WriteLine();

            IEnumerable<Car> myCar = LINQoverList2();

            foreach (var item in myCar)
            {
                Console.WriteLine("LIST<T>: [{0}, {1}, {2}, {3}]", item.PetName, item.Color, item.Speed, item.Make);
            }

            Console.WriteLine();

            Array myCarObjects = LINQoverList3();

            foreach (object item in myCarObjects)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine();

            //Applying LINQ to non-generic Collections (use Type<T>)

            string[] myStrList = LINQoverArrayList();

            foreach (string item in myStrList)
            {
                Console.WriteLine("ArrayList LINQ: " + item);
            }

            Console.ReadLine();
        }

    static IEnumerable<String> LINQoverList()
    {
        List<Car> myCar = new List<Car>()
            {
                new Car {PetName = "Scott", Color = "Red", Speed = 55, Make = "BMW" },
                new Car {PetName = "Crystal", Color = "Blue", Speed = 100, Make = "Ford" },
                new Car {PetName = "Griffin", Color = "Green", Speed = 5, Make = "Chevy" },
                new Car {PetName = "Marielle", Color = "Red", Speed = 24, Make = "Nissan" },
                new Car {PetName = "Heidi", Color = "Black", Speed = 2, Make = "Truck" },
                new Car {PetName = "Super Why", Color = "Silver", Speed = 75, Make = "BMW" }

            };

        var color = from c in myCar
                    where c.Color == "Red"
                    orderby c.PetName
                    select c.PetName;

        return color;
    }


    static IEnumerable<Car> LINQoverList2()
    {
        List<Car> myCar = new List<Car>()
            {
                new Car {PetName = "Scott", Color = "Red", Speed = 55, Make = "BMW" },
                new Car {PetName = "Crystal", Color = "Blue", Speed = 100, Make = "Ford" },
                new Car {PetName = "Griffin", Color = "Green", Speed = 5, Make = "Chevy" },
                new Car {PetName = "Marielle", Color = "Red", Speed = 24, Make = "Nissan" },
                new Car {PetName = "Heidi", Color = "Black", Speed = 2, Make = "Truck" },
                new Car {PetName = "Super Why", Color = "Silver", Speed = 75, Make = "BMW" }

            };

        var car = from c in myCar
                  where c.Make == "BMW"
                  orderby c.PetName
                  select c;

        return car;
    }


    static Array LINQoverList3()
    {
        List<Car> myCar = new List<Car>()
            {
                new Car {PetName = "Scott", Color = "Red", Speed = 55, Make = "BMW" },
                new Car {PetName = "Crystal", Color = "Blue", Speed = 100, Make = "Ford" },
                new Car {PetName = "Griffin", Color = "Green", Speed = 5, Make = "Chevy" },
                new Car {PetName = "Marielle", Color = "Red", Speed = 24, Make = "Nissan" },
                new Car {PetName = "Heidi", Color = "Black", Speed = 2, Make = "Truck" },
                new Car {PetName = "Super Why", Color = "Silver", Speed = 75, Make = "BMW" }

            };

        var car = from c in myCar
                  where c.Speed > 50
                  orderby c.PetName
                  select new { c.PetName, c.Speed };

        return car.ToArray();
    }

    static string[] LINQoverArrayList()
    {
        ArrayList myList = new ArrayList();

        myList.AddRange(new object[] { 10, 7.6, new Car(), "The Zion Family", "Blue", 105, "The Test", "Hello Bill" });
        myList.Add(Math.PI);

        var stringList = myList.OfType<string>();

        var list = from str in stringList
                   where str.Contains("The")
                   select str;

        return list.ToArray();

    }
}

}

namespace Interfacepractice
{

    public interface IComparer<T>
    {
        int Compare(T x, T y);
    }

    public class PersonComparer : IComparer<Person>
    {
        /// <summary>
        /// 나이 오름차순
        /// </summary>
        public int Compare(Person x, Person y)
        {
            //int? ret;
            //if ((ret = (x as Person)?.Age - (y as Person)?.Age) == null)
            //{
            //    //null 일때 동작할 코드
            //}
            //return ret.Value;
            return x.Age - y.Age;
        }
    }

    public class AnimalComparer : IComparer<Animal>
    {
        /// <summary>
        /// 이름 내림차순
        /// </summary>
        public int Compare(Animal x, Animal y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }

    public class CarComparer : IComparer<Car>
    {
        /// <summary>
        /// 년도 오름차순
        /// </summary>
        public int Compare(Car x, Car y)
        {
            return y.Year - x.Year;
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public class Animal
    {
        public string Name { get; set; }
        public int Legs { get; set; } // 다리 개수

        public Animal(string name, int legs)
        {
            Name = name;
            Legs = legs;
        }
    }

    public interface ISorter
    {
        void Sort<T>(T[] array, IComparer<T> comparer);
    }

    public class BubbleSort : ISorter
    {
        public void Sort<T>(T[] array, IComparer<T> comparer)
        {
            if (array.Length <= 1)
                return;

            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j < i; j++)
                {
                    if (comparer.Compare(array[j], array[j + 1]) > 0)
                        (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }

    public class SelectionSort : ISorter
    {
        public void Sort<T>(T[] array, IComparer<T> comparer)
        {
            if (array.Length <= 1)
                return;

            for (int i = 0; i < array.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (comparer.Compare(array[j], array[min]) < 0)
                        min = j;
                }
                (array[i], array[min]) = (array[min], array[i]);
            }
        }
    }

    public class InsertionSort : ISorter
    {
        public void Sort<T>(T[] array, IComparer<T> comparer)
        {
            if (array.Length <= 1)
                return;

            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    if (comparer.Compare(array[j], array[j - 1]) >= 0)
                        break;

                    (array[j], array[j - 1]) = (array[j - 1], array[j]);
                }
            }
        }
    }

    public class Car
    {
        public string Model { get; set; }
        public int Year { get; set; }

        public Car(string model, int year)
        {
            Model = model;
            Year = year;
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            Person[] people = {
            new Person("John", 30),
            new Person("Jane", 25),
            new Person("Jake", 28)
            };

            ISorter sorter = new BubbleSort();
            //ISorter sorter = new InsertionSort();
            //ISorter sorter = new SelectionSort();
            sorter.Sort(people, new PersonComparer());

            Console.WriteLine();
            foreach (Person person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }

            Animal[] animals = {
            new Animal("Dog", 4),
            new Animal("Spider", 8),
            new Animal("Bird", 2)
            };

            sorter = new BubbleSort();
            //sorter = new InsertionSort();
            //sorter = new SelectionSort();
            sorter.Sort(animals, new AnimalComparer());

            Console.WriteLine();
            foreach (Animal animal in animals)
            {
                Console.WriteLine($"Name: {animal.Name}, Legs: {animal.Legs}");
            }

            Car[] cars = {
            new Car("Tesla Model S", 2020),
            new Car("Ford Model T", 1927),
            new Car("Volkswagen Beetle", 1965)
            };

            sorter = new BubbleSort();
            //sorter = new InsertionSort();
            //sorter = new SelectionSort();
            sorter.Sort(cars, new CarComparer());
            
            Console.WriteLine();
            foreach (Car car in cars)
            {
                Console.WriteLine($"Model: {car.Model}, Year: {car.Year}");
            }
        }
    }
}


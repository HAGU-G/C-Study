using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2024_04_05
{
    //1. 프로퍼티로 변경
    class NameCard
    {
        private int age;
        private string name;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
    }

    //2. 무명 형식
    class P_09
    {
        public static void TestCode()
        {
            var nameCard = new { Name = "이름", Age = 1 };
            Console.WriteLine("이름:{0}, 나이:{1}", nameCard.Name, nameCard.Age);

            var complex = new { Real = 3, Imaginary = 4 };
            Console.WriteLine("Real:{0}, Imaginary:{1}",
                complex.Real, complex.Imaginary);
        }
    }
}

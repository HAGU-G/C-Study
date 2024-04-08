using System.Collections;
using System.Numerics;

namespace _2024_04_05
{
    //1. 1번

    //2.
    class P_10
    {
        public static T[,] MetricsProduct<T>(T[,] a, T[,] b) where T : IMultiplyOperators<T, T, T>, IAdditionOperators<T, T, T>
        {
            //좌항의 열과 우항의 행이 같은 크기인지 검사
            ArgumentOutOfRangeException.ThrowIfNotEqual(a.GetLength(1), b.GetLength(0),"좌항의 열과 우항의 행의 크기가 같아야합니다.");

            //좌항의 행, 우항의 열의 크기로 새로운 가진 행렬 생성
            T[,] temp = new T[a.GetLength(0), b.GetLength(1)];

            //행렬곱
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    for(int k = 0; k < a.GetLength(1) ;k++)
                    {

                        temp[i, j] += a[i, k] * b[k, j];
                    }
                }
            }

            return temp;
        }

        //3. 출력 결과: 5
        //              4
        //              3
        //              2
        //              1

        //4. 출력 결과: 1
        //              2
        //              3
        //              4
        //              5

        public static void TestCode()
        {
            int[,] a ={
                {1, 2, 3},
                {3, 4, 6}};
            int[,] b ={
                {1, 2, 3},
                {1, 2, 3},
                {3, 4, 6}};
            int[,] c = MetricsProduct(a, b);

            foreach (int i in c)
            {
                Console.WriteLine(i);
            }

            //5. 코드 완성
            Hashtable ht = new Hashtable();
            ht["회사"] = "Microsoft";
            ht["URL"] = "www.microsoft.com";

            Console.WriteLine("회사 : {0}", ht["회사"]);
            Console.WriteLine("URL : {0}", ht["URL"]);


        }
    }


}

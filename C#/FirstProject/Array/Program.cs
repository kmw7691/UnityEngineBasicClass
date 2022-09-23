using System;

namespace Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrInt = new int[3];
            int[] arrInt2 = { 1, 2, 3 };
            Console.WriteLine("Hello World!");
            arrInt = new int[3];
            float[] arrFloat = new float[4];

            // 배열의 인덱스 접근
            // 배열변수이름[인덱스숫자]
            // : 배열의 가장 첫번째 주소로부터 인덱스숫자 x 배열의 요소의 자료형 크기 만큼
            // 뒤에 있는 배열 요소에 접근
            arrInt[0] = 3;
            arrInt[1] = 2;
            arrInt[2] = 1;
            Console.WriteLine(arrInt[0]);
            Console.WriteLine(arrInt[1]);
            Console.WriteLine(arrInt[2]);

            string name = "Luke";
            Console.WriteLine(name[1]);
            char[] arrChar = new char[5];
            arrChar[0] = 'L';
            arrChar[1] = 'U';
            arrChar[2] = 'K';
            arrChar[3] = 'E';

            string[] arrString = new string[3];
            arrString[0] = "김아무개";
            arrString[1] = "박아무개";
            arrString[2] = "이아무개";
        }
    }
}

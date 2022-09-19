using System;

namespace If_Statement
{
    class Program
    {
        static void Main(string[] args)
        {
            bool condition1 = false;
            bool condition2 = true;
            bool condition3 = true;

            if (condition1)
            {
                //조건이 참일때 실행할 내용
                Console.WriteLine("조건1은 참이다");
            }

            else if (condition2)
            {
                Console.WriteLine("조건1은 거짓이고 조건2는 참이다");
            }

            else if (condition3)
            {
                Console.WriteLine("조건1,2는 거짓이고 조건3는 참이다");
            }

            else
            {
                //조건이 참이 아닐때 실행할 내용
                Console.WriteLine("조건1,2,3 모두 거짓이다");
            }
        }
    }
}

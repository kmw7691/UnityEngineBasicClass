using System;

namespace Statement_SwitchCase_And_Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            int state = 0;

            switch (state)
            {
                case 0:
                    Console.WriteLine("상태다 0이다");
                    break;  // break 분기문 : 현재 흐름에서 벗어남(상위 문법에서 빠져나옴)

                case 1:
                    Console.WriteLine("상태다 1이다");
                    break;

                case 2:
                    Console.WriteLine("상태다 2이다");
                    break;
                default:
                    break;
            }
        }
    }
}

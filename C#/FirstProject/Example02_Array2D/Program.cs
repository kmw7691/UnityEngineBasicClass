using System;

namespace Example02_Array2D
{
    class Program
    {
        static int[,] map = new int[5, 5]
        {
            {0, 0, 0, 0, 1},
            {0, 1, 1, 1, 1},
            {0, 0, 0, 1, 1},
            {1, 1, 0, 0, 0},
            {0, 1, 1, 0, 0}
        };

        static void Main(string[] args)
        {
            Player player = new Player(3,0);
            map[0, 3] = 2;

            while (true)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "MoveLeft":
                        player.MoveLeft(map);
                        break;

                    case "MoveRight":
                        player.MoveRight();
                        break;

                    case "MoveUp":
                        player.MoveUp();
                        break;

                    case "MoveDown":
                        player.MoveDown();
                        break;

                    default:
                        Console.WriteLine("Wrong input");
                        break;
                }

                DisplayMap();
            }
        }

        static void DisplayMap()
        {
            for (int j = 0; j < map.GetLength(0); j++)
            {
                for (int i = 0; i < map.GetLength(1); i++)
                {
                    if (map[j, i] == 0)
                        Console.Write("□");
                    else if (map[j, i] == 1)
                        Console.Write("■");
                    else if (map[j, i] == 2)
                        Console.Write("▣");
                }
                Console.WriteLine();
            }
        }

        class Player
        {
            private int _x;
            private int _y;

            public Player(int x, int y)
            {
                _x = x;
                _y = y;
            }


            public void MoveLeft(int[,] map)
            {
                // 맵 범위를 넘어가는지 체크
                if(_x-1 <0)
                    Console.WriteLine($"플레이어 좌측이동 불가(경계초과), 현재위치 : {_x},{_y}");
                
                else if(map[_y,_x-1] != 0)
                    Console.WriteLine($"플레이어 좌측이동 불가(길이없음), 현재위치 : {_x},{_y}");
                
                else
                {
                    map[_y, _x--] = 0;
                    map[_y, _x] = 2;
                    Console.WriteLine($"플레이어 좌측으로 한칸 이동. 현재위치 : {_x},{_y}");
                }    
            }
            public void MoveRight()
            {
                if (_x + 1 > 4 )
                    Console.WriteLine($"플레이어 우측이동 불가(경계초과), 현재위치 : {_x},{_y}");

                else if (map[_y, _x - 1] != 0)
                    Console.WriteLine($"플레이어 우측이동 불가(길이없음), 현재위치 : {_x},{_y}");

                else
                {
                    map[_y, _x++] = 0;
                    map[_y, _x] = 2;
                    Console.WriteLine($"플레이어 우측으로 한칸 이동. 현재위치 : {_x},{_y}");
                }
            }
            public void MoveUp()
            {
                if (_y + 1 > 4)
                    Console.WriteLine($"플레이어 상측이동 불가(경계초과), 현재위치 : {_x},{_y}");

                else if (map[_y + 1, _x] != 0)
                    Console.WriteLine($"플레이어 상측이동 불가(길이없음), 현재위치 : {_x},{_y}");

                else
                {
                    map[_y++, _x] = 0;
                    map[_y, _x] = 2;
                    Console.WriteLine($"플레이어 상측으로 한칸 이동. 현재위치 : {_x},{_y}");
                }
            }
            public void MoveDown()
            {
                if (_y - 1 < 0)
                    Console.WriteLine($"플레이어 하측이동 불가(경계초과), 현재위치 : {_x},{_y}");

                else if (map[_y - 1, _x] != 0)
                    Console.WriteLine($"플레이어 하측이동 불가(길이없음), 현재위치 : {_x},{_y}");

                else
                {
                    map[_y--, _x] = 0;
                    map[_y, _x] = 2;
                    Console.WriteLine($"플레이어 하측으로 한칸 이동. 현재위치 : {_x},{_y}");
                }
            }
        }

    }
}

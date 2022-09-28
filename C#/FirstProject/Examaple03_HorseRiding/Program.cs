using System;
using System.Threading;

namespace Examaple03_HorseRiding
{
    public class Horse
    {
        public string Name;
        public int Position;
        public int Grade;
        public bool IsFinished;

        public void Run(int distance)
        {
            Position += distance;
        }
    }


    internal class Program
    {
        //const 키워드
        //constant (상수) 처리 키워드
        //초기화 이후 값을 수정할 수 없도록 하는 키워드
        const int TOTAL_HORSE_NUMBER = 5;
        const int DISTANCE_MIN = 10;
        const int DISTANCE_MAX = 20;
        const int GOAL_POSITION = 200;

        static void Main(string[] args)
        {
            Horse[] horses = new Horse[TOTAL_HORSE_NUMBER];
            Horse[] finishedHorses = new Horse[TOTAL_HORSE_NUMBER];

            int grade = 0;

            Random rand = new Random();

            for (int i = 0; i < TOTAL_HORSE_NUMBER; i++)
            {
                horses[i] = new Horse();
                horses[i].Name = $"경주마{i + 1}";
            }

            int count = 0;
            //경주
            while (grade < TOTAL_HORSE_NUMBER)
            {
                for (int i = 0; i < TOTAL_HORSE_NUMBER; i++)
                {
                    if (horses[i].IsFinished == false)
                    {
                        horses[i].Run(rand.Next(DISTANCE_MIN, DISTANCE_MAX + 1));

                        if(horses[i].Position >= GOAL_POSITION)
                        {
                            horses[i].IsFinished = true;
                            finishedHorses[grade] = horses[i];
                            grade++;
                            horses[i].Grade = grade;
                        }
                    }

                    if(horses[i].IsFinished)
                        Console.WriteLine($"{horses[i].Name}은 도착함");
                    else
                        Console.WriteLine($"{horses[i].Name}의 현재 위치 : {horses[i].Position}");
                }

                Thread.Sleep(1000); // 1초 슬립
                count++;
                Console.WriteLine($"=========================================={count}초 경과 ==========================================");
            }

            for (int i = 0; i < TOTAL_HORSE_NUMBER; i++)
            {
                Console.WriteLine($"{finishedHorses[i].Grade}등 : {finishedHorses[i].Name}");
            }
        }
    }
}

using System;

//구조체
//사용자정의자료형
//멤버변수, 멤버함수를 가짐
//생성자가 있음
    //단, 생성자는 매개변수로 모든 멤버변수에 대응되는 파라미터를 가지고 있어야하며
    //생성자 호출시 모든 멤버변수는 초기화 되어야 한다
    //WHY?
    //구조체는 값 형식이고 스택영역에 할당되기 때문

//구조체 vs 클래스
//모든 멤버의 크기 합이 16byte를 초과할 경우 클래스를 사용       (최우선 조건)
//값의 전달이 빈번하게 일어나는 경우 구조체를 사용               (ex/ 함수에 인자로 전달해야 하는 경우)
//잠깐 썼다가 사라지는 경우가 잦을때는 구조체를 사용             (클래스타입 객체 해제시 가비지컬렉션 부하 증가)


namespace Structure
{
    public struct Stats
    {
        public int STR;
        public int DEX;
        public int INT;
        public int LUK;


        public int CalcCombatPoint()
        {
            return STR + DEX + INT + LUK;
        }
    }

    public struct Stats_Class
    {
        public int STR;
        public int DEX;
        public int INT;
        public int LUK;
    }

        public class Warrior
    {
        public Stats Stats;
    }

    public struct WarriorFamily
    {
        public Warrior warrior1;  // 스택영역에 참조 주소만 가지고있음
        public Warrior warrior2;
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //스택영역에 할당
            Stats stats = new Stats()
            {
                STR = 100,
                DEX = 200,
                INT = 400,
                LUK = 800
            };

            Stats_Class statsClass = new Stats_Class()
            {
                STR = 100,
                DEX = 200,
                INT = 400,
                LUK = 800
            };

            Warrior warrior = new Warrior();

            //warrior.Stats는 힙영역
            Console.WriteLine(warrior.Stats.CalcCombatPoint());
        }
    }
}

using System;

namespace ClassObjectInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            // new 키워드
            // 동적할당 키워드
            // 객체화 : 클래스타입의 멤버들만큼의 공간을 할당하는 과정
            // 객체 : 클래스타입의 멤버들만큼 할당된 메모리 공간
            // 인스턴스화 : 객체에 실제 데이터를 대입하는 과정
            // 인스턴스 : 객체는 객체인데
            Human human = new Human();
            //Console.WriteLine(Marshal.Sizeof)

            human.age = 28;
            human.height = 177.2f;
            human.name = "홍길동";
            human.Breath();

            Console.WriteLine(human.height);
            Console.WriteLine($"성별 : {human.genderCharacter}");

            Console.WriteLine(Human.Instance.name);



            Human human2 = new Human();
            human2.height = 160.0f;
            human2.name = "만수";
            human2.Breath();

            Console.WriteLine(Human.Instance.name);

           //Human.Instance
        }
    }

    public class Human
    {
        // static 키워드
        // 객체화가 불가능한 키워드 -> Human클래스타입의 객체를 만들었을 때 해당 객체에는 Instance라는 멤버변수가 없다
        public static Human Instance;

        // 보호수준을 결정하는 접근제한자
        // public : 접근제한 x
        // private : 해당 객체 외 접근 제한
        // protected : 해당 객체
        public int age = 1;                
        public float height = 160.0f;           
        public double weight;          
        public bool isResting;         
        public char genderCharacter;   
        public string name;            

        // 생성자
        // 객체를 생성하는 함수
        // 객체를 생성한다는 의미 : 해당 클래스타입의 멤버들을 위한 메모리공간을 전부 확보함
        // 생성자도 기본적으로 함수
        // 변환형은 힙 영역에 동적할당한 객체의 참조

        // 참조란 ?
        // 특정 메모리의 주소를 가지고 있으며 해당 주소의 데이터를 읽고 쓸 수 있는 형태

        // 값 형식 vs 참조 형식
        // 값 형식 : 스택 영역에 데이터가 할당됨
        // ex) int, float, double, char, struct ..
        // 참조 형식 : 힙 영역에 데이터가 할당됨
        // ex) class, array, string, ...
        public Human()
        {
            // this 키워드
            // 객체 자기자신 참조 반환 키워드
            Instance = this;

            height = 160.0f;
            weight = 300.0f;
            isResting = false;
        }

        // 소멸자
        // 해당 객체를 메모리에서 해제할때 호출하는 함수
        // 가비지컬렉터가 해당 객체가 참조되지 않을 경우 호출해주기때문에 직접 호출하는 일은 없다
        ~Human()
        {

        }

        public void Breath()
        {
            Console.WriteLine($"{this.name}(이)가 숨을 쉰다");
        }
    }
}

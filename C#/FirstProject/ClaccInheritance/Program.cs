using System;

namespace ClassInheritance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 추상화 클래스는 인스턴스화 할 수 없다
            //Creature creature = new Creature();

            Human human = new Human();
            human.Breath();
            human.PurchaseParkingPass();
            human.Name = "MAN";
            human.PhoneNumber = 012341;
            human.EmailAddress = "sagsdf";


            Human Luke = new Human("Luke",01012345678,"kmw7691@naver.com");
            Console.WriteLine(Luke.EmailAddress);

            Student student = new Student();
            student.PurchaseParkingPass();
            student.StudentNumber = 20220929;


            //Covariant 공변성
            Human human1 = new Student();
            Creature creature1 = new Student();
            creature1 = human1;


            creature1.Breath();
            human1.Breath();
            

            Professor professor = new Professor();
            professor.PurchaseParkingPass();
            professor.PurchaseParkingPass(30.0f);


            Dog dog = new Dog();
            dog.Breath();

            Elephant elephant = new Elephant();

            dog.FourLeggedWalk();
            elephant.FourLeggedWalk();

            i_FourLeggedWalker[] fourLeggedWalkers = new i_FourLeggedWalker[]
            {
                dog, elephant
            };

            for (int i = 0; i < fourLeggedWalkers.Length; i++)
            {
                fourLeggedWalkers[i].FourLeggedWalk();
            }
        }
    }
}
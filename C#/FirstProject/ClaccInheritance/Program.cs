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

            Dog dog = new Dog();
            dog.Breath();

            Student student = new Student();
            student.PurchaseParkingPass();

            //Covariant 공변성
            Human human1 = new Student();
            Creature creature1 = new Student();
            creature1 = human1;

            creature1.Breath();
            human1.Breath();
            

            Professor professor = new Professor();
            professor.PurchaseParkingPass();
            professor.PurchaseParkingPass(30.0f);
        }
    }
}
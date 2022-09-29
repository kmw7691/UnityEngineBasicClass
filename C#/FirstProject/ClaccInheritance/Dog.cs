using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritance
{
    class Dog : Creature
    {
        public override void Breath()
        {
            Console.WriteLine("개가 숨을 쉰다");
        }
    }
}

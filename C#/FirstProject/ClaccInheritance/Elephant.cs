using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritance
{
    class Elephant : Creature, i_FourLeggedWalker
    {
        public override void Breath()
        {
            
        }

        public void FourLeggedWalk()
        {
            Console.WriteLine("코끼리가 사족보행한다"); 
        }
    }
}

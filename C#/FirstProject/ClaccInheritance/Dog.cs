﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassInheritance
{
    class Dog : Creature, i_FourLeggedWalker
    {
        public override void Breath()
        {
            Console.WriteLine("개가 숨을 쉰다");
        }

        public void FourLeggedWalk()
        {
            Console.WriteLine("개가 사족보행한다");
        }
    }
}

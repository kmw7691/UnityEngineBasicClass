using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaccInheritance
{
    //abstract 키워드
    //추상 키워드
    //클래스  메소드  프로퍼터 앞에 붙을 수있다
    //추상 키워드가 붙은 멤버들은 인스턴스화 불가
    //반드시 해당클래스를 상속받은 자식 클래스에 추상 부분을 구현하고 사용해야함
    internal abstract class Creature
    {
        public string Species;
        public int LifeTime;
        public int mass;

        public void Breath()
        {

        }
    }
}

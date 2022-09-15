using System;

namespace Variables
{
    internal class Program
    {
        // bit : 한자리 이진수 (0과 1로 표현, 정보 처리의 최소 단위)
        // byte : 8 bit(cpu의 데이터 처리 최소 단위)

        //변수
        int index = 7;  // int는 4byte 부호가 있는 정수형
        // index는 7으로 초기화 되었다
        // index변수의 메모리공간에 7이라는 데이터를 대입
        // 7 == 2^2 + 2^1 + 2^0

        static void Main(string[] args)
        {

        }
    }

    // 전역변수 : 외부 클래스/객체등에서 (지역상관없이) 접근할 수 있는 변수

    public class Human
    {
        // 멤버변수 : 클래스/구조체 등을 구성하는 멤버로써 선언된 변수

        int age;                //4byte 정수형
        float height;           //4byte 실수형
        double weight;          //8byte 실수형
        bool isResting;         //1byte 논리형 (true / false 값을 가짐)
                                    // true: 0 이아님, false = 0
        char genderCharacter;   //2byte 문자형(ASCII 코드로 표현)
                                    //97 == 64 + 32 + 1 == 2^6 + 2^5 + 2^0
        string name;            //문자열형, 문자갯수 * 2byte + 1byte(null)
    }

}

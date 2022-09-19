using System;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            float a = 14;
            float b = 6;
            float c = 0;

            // 산술 연산자
            // 더하기 빼기 곱하기 나누기
            //===================================

            // 더하기
            c = a + b;
            Console.WriteLine(c);
            
            //빼기 
            c = a - b;
            Console.WriteLine(c);

            //곱하기
            c = a * b;
            Console.WriteLine(c);

            //나누기
            //정수연산시 몫만 반환, 실수연산시 소수점까지 연산
            c = a / b;
            Console.WriteLine(c);

            //나머지
            //정수던 실수던 정수 나머지결과 반환
            c = a % b;
            Console.WriteLine(c);

            //증감연산자
            //증가연산자, 감소연산자
            //======================================

            //증가연산
            ++c;    // 전위연산 : 해당 라인에서 연산을 먼저 수행한 후에 명령실행
            c++;    // 후위연산 : 해당 라인에서 명령을 먼저 수행한 후에 연산실행

            Console.WriteLine(++c);
            Console.WriteLine(c++);
            Console.WriteLine(c);

            //감소연산
            --c;
            c--;

            //관계연산자
            //같음, 다름, 크기비교 연산
            // 연산 결과가 참일경우 true, 거짓일 경우 false => 논리형 반환
            //============================================================

            //같음 비교
            Console.WriteLine(a == b);

            //다름 비교
            Console.WriteLine(a != b);

            //큰지 비교
            Console.WriteLine(a > b);

            //크거나 같은지 비교
            Console.WriteLine(a >= b);

            //작은지 비교
            Console.WriteLine(a < b);

            //작거나 같은지 비교
            Console.WriteLine(a <= b);

            //대입연산자
            //더해서 / 빼서 / 곱해서 / 나누어서 / 나머지연산후 대입하는 연산
            //===============================================================
            c = 20;
            c += b;     //==c = c + b;
            c -= b;
            c *= b;
            c /= b;
            c %= b;


            //논리연산자
            //or / and / xor / not
            //===========================================================
            bool A = true;
            bool B = false;

            //or
            //a와 b 둘중 하나라도 true면 true반환, 나머지경우 false 반환
            Console.WriteLine(A | B);

            //and
            //a와 b 둘다 true면 true반환, 나머지경우 false 반환
            Console.WriteLine(A & B);

            //xor
            //a와 b 둘중 하나만 true일때 true반환, 나머지경우 false반환
            Console.WriteLine(A ^ B);

            //not
            //피연산자가 true이면 false반환, false이면 true반환
            Console.WriteLine(!A);
        }
    }
}

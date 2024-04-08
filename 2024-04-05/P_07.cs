
namespace _2024_04_05
{
    //1. 클래스는 사용자 정의 데이터형이고 객체, 인스턴스는 클래스의 변수를 만든 것이다.

    //2. B d = new A();
    //  A는 B를 상속받지 않았다. B의 부모클래스이다.
    //  B로 형 변환이 불가능하다.

    //3. this는 셀프 레퍼런스이다. this로 자신의 멤버에 접근할 수 있다. 클래스의 생성자에서 자신의 다른 생성자를 호출할 때도 쓰인다.
    //  base는 자식 클래스에서 부모 클래스의 멤버에 접근할 때 사용한다. 생성자에서 부모 클래스의 생성자를 호출할 때도 쓰인다.

    //4. 구조체 설명 중 틀린 것
    //  2 -> 깊은 복사
    //  3 -> 값 형식

    //5. 컴파일&실행 가능하게 변경
    struct ACSetting
    {
        public double currentInCelesius;
        public double target;

        public double GetFahrenheit() //readonly 제거
        {
            target = currentInCelesius * 1.8 + 32;
            return target;
        }
    }

    //6. 프로그램 언어의 각 요소들(상수, 변수, 식, 오브젝트, 함수, 메소드 등)이 다양한 자료형(type)에 속하는 것이 허가되는 성질
    //  오버라이딩을 통해 상속받은 함수를 클래스마다 다른 동작을 하도록 변경할 수 있다. ex)인터페이스

    //7. 스위치 문으로 변경
    //private static double GetDiscountRate(object clinet)
    //{
    //    switch (clinet)
    //    {
    //        case ("학생", int n) when n < 18:
    //            return 0.2;
    //        case ("학생", _):
    //            return 0.1;
    //        case ("일반", int n) when n < 18:
    //            return 0.1;
    //        case ("일반", _):
    //            return 0.05;
    //        default:
    //            return 0;
    //    };
    //}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTone : MonoBehaviour
{
    //========================================
    //**    디자인 패턴 싱글톤 SingleTon		**
    //========================================
    /*
        <싱글톤 패턴>
        오직 한 개의 클래스 인스턴스만을 갖도록 보장
        이에 대한 전역적인 접근점을 제공

        구현 :
        1. 생성자의 접근권한을 외부에서 생성할 수 없도록 제한
        2. 정적변수를 활용하여 캡슐화를 진행
        3. 전역에서 접근 가능한 인스턴스의 주소를 갖기 위해
           데이터 영역 메모리 공간을 활용 (정적변수)
        4. GetInstrance 함수를 통해서 단일객체가 없는 경우 생성
        5. 단일객체가 있는 경우는 단일객체를 반환 해주도록 구현

        장점 :
        1. 하나뿐인 존재로 주요 클래스, 관리자의 역할을 함
        2. 전역적 접근으로 참조에 필요한 작업이 없이 빠른접근가능
        3. 인스턴스들이 싱글톤을 통하여 데이터를 공유하기 쉬워짐

        단점 :
        1. 싱글톤이 너무 많은 책임을 짊어지는 경우를 주의해야함
        2. 싱글톤의 남발로 전역접근이 많아지게 되는 경우, 참조한 코드 결합도가 높아짐
        3. 싱글톤의 데이터를 공유할 경우 데이터 변조에 주의해야함
    */

    public class SingleTon
    {
        private static SingleTon instance;

        public static SingleTon GetInstance()
        {
            if (instance == null)           // 인스턴스가 null이면
                instance = new SingleTon(); // 만들어준다
            return instance;                // 그리고 인스턴스를 리턴해준다
                                            // 만약에 이미 생성해서 존재한다면 만들어진 인스턴스를 리턴해준다
        }
        

        private SingleTon() { }             // 외부에서 인스턴스를 추가로 생성하는 것을 방지
    }

    public class Player
    {
        public SingleTon a = SingleTon.GetInstance();       // 여기서 생성된 싱글톤
    }

    public class Monster
    {
        public SingleTon b = SingleTon.GetInstance();       // 위에서 만든 싱글톤과 같다
    }

    public class Item
    {
        public SingleTon c = SingleTon.GetInstance();       // 마찬가지로 같다
    }

    // 또다른 예시

    public class Inventory
    {
        private static Inventory inventory;
        public static int money;
        public static Inventory GetInstance()
        {
            if (inventory == null)           
                inventory = new Inventory(); 
            return inventory;                
                                            
        }

        private Inventory() { }             
    }

    public class Player2
    {
        public void SpendMoney()
        {
            // 여기다가 인벤토리에 있는 머니를 사용하는 기능을 추가
        }
    }

    // 아이템 클래스에서
    // 돈을 얻었으면 인벤토리 안의 머니를 증가
    // 인벤토리를 불러옴
}

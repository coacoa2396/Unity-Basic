using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTone : MonoBehaviour
{
    //========================================
    //**    ������ ���� �̱��� SingleTon		**
    //========================================
    /*
        <�̱��� ����>
        ���� �� ���� Ŭ���� �ν��Ͻ����� ������ ����
        �̿� ���� �������� �������� ����

        ���� :
        1. �������� ���ٱ����� �ܺο��� ������ �� ������ ����
        2. ���������� Ȱ���Ͽ� ĸ��ȭ�� ����
        3. �������� ���� ������ �ν��Ͻ��� �ּҸ� ���� ����
           ������ ���� �޸� ������ Ȱ�� (��������)
        4. GetInstrance �Լ��� ���ؼ� ���ϰ�ü�� ���� ��� ����
        5. ���ϰ�ü�� �ִ� ���� ���ϰ�ü�� ��ȯ ���ֵ��� ����

        ���� :
        1. �ϳ����� ����� �ֿ� Ŭ����, �������� ������ ��
        2. ������ �������� ������ �ʿ��� �۾��� ���� �������ٰ���
        3. �ν��Ͻ����� �̱����� ���Ͽ� �����͸� �����ϱ� ������

        ���� :
        1. �̱����� �ʹ� ���� å���� �������� ��츦 �����ؾ���
        2. �̱����� ���߷� ���������� �������� �Ǵ� ���, ������ �ڵ� ���յ��� ������
        3. �̱����� �����͸� ������ ��� ������ ������ �����ؾ���
    */

    public class SingleTon
    {
        private static SingleTon instance;

        public static SingleTon GetInstance()
        {
            if (instance == null)           // �ν��Ͻ��� null�̸�
                instance = new SingleTon(); // ������ش�
            return instance;                // �׸��� �ν��Ͻ��� �������ش�
                                            // ���࿡ �̹� �����ؼ� �����Ѵٸ� ������� �ν��Ͻ��� �������ش�
        }
        

        private SingleTon() { }             // �ܺο��� �ν��Ͻ��� �߰��� �����ϴ� ���� ����
    }

    public class Player
    {
        public SingleTon a = SingleTon.GetInstance();       // ���⼭ ������ �̱���
    }

    public class Monster
    {
        public SingleTon b = SingleTon.GetInstance();       // ������ ���� �̱���� ����
    }

    public class Item
    {
        public SingleTon c = SingleTon.GetInstance();       // ���������� ����
    }

    // �Ǵٸ� ����

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
            // ����ٰ� �κ��丮�� �ִ� �Ӵϸ� ����ϴ� ����� �߰�
        }
    }

    // ������ Ŭ��������
    // ���� ������� �κ��丮 ���� �Ӵϸ� ����
    // �κ��丮�� �ҷ���
}

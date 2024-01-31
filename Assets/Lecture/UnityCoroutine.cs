using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
    /************************************************************************
	 * �ڷ�ƾ (Coroutine)
	 * 
	 * �۾��� �ټ��� �����ӿ� �л��� �� �ִ� �񵿱�� �۾�
	 * �ݺ������� �۾��� �л��Ͽ� �����ϸ�, ������ �Ͻ������ϰ� �ߴ��� �κк��� �ٽý����� �� ����
	 * ��, �ڷ�ƾ�� �����尡 �ƴϸ� �ڷ�ƾ�� �۾��� ������ ���� �����忡�� ����
	 ************************************************************************/

    // <�ڷ�ƾ ����>
    // �ݺ������� �۾��� StartCorouine�� ���� ����

    IEnumerator SubRoutine()
    {
        for (int i = 0; i < 10; i++)
        {
            yield return new WaitForSeconds(1);
            Debug.Log("�ڷ�ƾ 1��");
        }
    }

    private Coroutine routine;          // routine�̶� �̸��� �ڷ�ƾ ����
    private void CoroutineStart()
    {
        routine = StartCoroutine(SubRoutine());         // ������ ���� routine�� ��ŸƮ�ڷ�ƾ �Լ��� ����
    }

    // <�ڷ�ƾ ����>
    // StopCoroutine�� ���� ���� ���� �ڷ�ƾ ����
    // StopAllCoroutine�� ���� ���� ���� ��� �ڷ�ƾ ����
    // �ݺ������� �۾��� ��� �Ϸ�Ǿ��� ��� �ڵ� ����
    // �ڷ�ƾ�� �����Ų ��ũ��Ʈ�� ��Ȱ��ȭ�� ��� �ڵ� ����

    private void CoroutineStop()
    {
        StopCoroutine(routine);     // routine�� ������ �ڷ�ƾ ����
        StopAllCoroutines();        // ��� �ڷ�ƾ ����
    }

    // <�ڷ�ƾ �ð� ����>
    // �ڷ�ƾ�� �ð� ������ �����Ͽ� �ݺ������� �۾��� ���� Ÿ�̹��� ������ �� ����
    IEnumerator CoRoutineWait()
    {
        yield return new WaitForSeconds(1);     // n�ʰ� �ð�����
        yield return null;                      // �ð����� ����
    }

    void Start()
    {
        StartCoroutine(JumpCoolTimeRoutine());
    }

    IEnumerator JumpCoolTimeRoutine()
    {
        Debug.Log("���� ����");
        yield return new WaitForSeconds(2f);
        Debug.Log("���� ��");
    }
    void Update()
    {
        
    }
}

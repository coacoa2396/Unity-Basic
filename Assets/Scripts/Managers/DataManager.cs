using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DataManager : MonoBehaviour
{
    [SerializeField] int fireCount;
    [SerializeField] int tankVelocity;
    public UnityAction<int> OnFireCountChanged;     // Model : ���⼭ ���� ���� ������ ��
    
    private GameObject findWithTag;
    [SerializeField] Rigidbody rigid;
    
    public void Awake()
    {
        if (GameObject.FindWithTag("Player") != null)
        {
            findWithTag = GameObject.FindWithTag("Player");
            rigid = findWithTag.GetComponent<Rigidbody>();
        }
    }
    public int FireCount 
    {
        set { fireCount = value; OnFireCountChanged?.Invoke(value); } 
        get { return fireCount; } 
    }

    private void LateUpdate()
    {
        tankVelocity = (int)rigid.velocity.magnitude;
    }
    public int TankVelocity
    {        
        get { return tankVelocity; }
    }
    /*
    public void AddFireCount()
    {
        fireCount++;
    }
    */
}

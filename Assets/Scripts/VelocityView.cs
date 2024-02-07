using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VelocityView : MonoBehaviour
{
    public TMP_Text text;

    private void LateUpdate()
    {
        UPdateView(Manager.Data.TankVelocity);        
    }
    private void UPdateView(int value)
    {
        value = Manager.Data.TankVelocity;
        text.text = value.ToString();
    }
}

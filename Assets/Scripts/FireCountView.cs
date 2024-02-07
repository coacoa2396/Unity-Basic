using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FireCountView : MonoBehaviour  // View : 절대로 실제 값을 가지게 하면 안됨
{
    public TMP_Text text;

    private void OnEnable()
    {
        UpdateView(Manager.Data.FireCount);
        Manager.Data.OnFireCountChanged += UpdateView;
    }

    private void OnDisable()
    {
        Manager.Data.OnFireCountChanged -= UpdateView;
    }

    private void UpdateView(int value)
    {
        text.text = value.ToString();
    }
}

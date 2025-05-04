using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("测试");
    }

    void Update()
    {
    }
}
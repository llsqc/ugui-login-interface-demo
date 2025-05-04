using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    void Start()
    {
        UIManager.Instance.ShowPanel<BackPanel>();
        UIManager.Instance.ShowPanel<LoginPanel>();
    }

    void Update()
    {
    }
}
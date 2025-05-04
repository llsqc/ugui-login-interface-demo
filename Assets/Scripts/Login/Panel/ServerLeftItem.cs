using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ServerLeftItem : MonoBehaviour
{
    public Button btnSelf;
    public Text txtInfo;

    private int _beginIndex;
    private int _endIndex;

    void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {
            ServerListPanel panel = UIManager.Instance.GetPanel<ServerListPanel>();
            panel.UpdatePanel(_beginIndex, _endIndex);
        });
    }

    public void InitInfo(int beginIndex, int endIndex)
    {
        _beginIndex = beginIndex;
        _endIndex = endIndex;

        txtInfo.text = $"{beginIndex} - {endIndex}区";
    }

    void Update()
    {
    }
}
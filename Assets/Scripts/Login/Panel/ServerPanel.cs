using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ServerPanel : BasePanel
{
    public Button btnStart;
    public Button btnChange;
    public Button btnBack;

    public Text txtServer;

    public override void Init()
    {
        btnBack.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<LoginPanel>();
            UIManager.Instance.HidePanel<ServerPanel>();
        });

        btnStart.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ServerPanel>();
            SceneManager.LoadScene("GameScene");
        });

        btnChange.onClick.AddListener(() => { UIManager.Instance.HidePanel<ServerPanel>(); });
    }

    public override void ShowMe()
    {
        base.ShowMe();
    }
}
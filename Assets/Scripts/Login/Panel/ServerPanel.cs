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
            if (LoginMgr.Instance.LoginData.isAutoLogin)
            {
                LoginMgr.Instance.LoginData.isAutoLogin = false;
            }

            UIManager.Instance.ShowPanel<LoginPanel>();
            UIManager.Instance.HidePanel<ServerPanel>();
        });

        btnStart.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<ServerPanel>();
            UIManager.Instance.HidePanel<BackPanel>();

            LoginMgr.Instance.SaveLoginData();
            SceneManager.LoadScene("GameScene");
        });

        btnChange.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<ServerListPanel>();
            UIManager.Instance.HidePanel<ServerPanel>();
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        int id = LoginMgr.Instance.LoginData.lastServerID;
        if (id <= 0)
        {
            txtServer.text = "无";
        }
        else
        {
            ServerInfo info = LoginMgr.Instance.ServerData[id - 1];
            txtServer.text = $"{info.id}区 {info.name}";
        }
    }
}
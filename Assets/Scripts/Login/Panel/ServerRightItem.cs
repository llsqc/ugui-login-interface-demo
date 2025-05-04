using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ServerRightItem : MonoBehaviour
{
    public Button btnSelf;
    public Image imgNew;
    public Image imgState;

    public Text txtName;
    public ServerInfo nowServerInfo;

    void Start()
    {
        btnSelf.onClick.AddListener(() =>
        {
            LoginMgr.Instance.LoginData.lastServerID = nowServerInfo.id;
            UIManager.Instance.HidePanel<ServerListPanel>();
            UIManager.Instance.ShowPanel<ServerPanel>();
        });
    }

    public void InitInfo(ServerInfo info)
    {
        nowServerInfo = info;

        txtName.text = info.id + "区 " + info.name;
        imgNew.gameObject.SetActive(info.isNew);

        imgState.gameObject.SetActive(true);
        SpriteAtlas atlas = Resources.Load<SpriteAtlas>("Login");
        switch (info.state)
        {
            case 0:
                imgState.gameObject.SetActive(false);
                break;
            case 1:
                imgState.sprite = atlas.GetSprite("ui_DL_fanhua_01");
                break;
            case 2:
                imgState.sprite = atlas.GetSprite("ui_DL_huobao_01");
                break;
            case 3:
                imgState.sprite = atlas.GetSprite("ui_DL_liuchang_01");
                break;
            case 4:
                imgState.sprite = atlas.GetSprite("ui_DL_weihu_01");
                break;
        }
    }

    void Update()
    {
    }
}
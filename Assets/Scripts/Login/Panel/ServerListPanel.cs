using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class ServerListPanel : BasePanel
{
    public ScrollRect svLeft;
    public ScrollRect svRight;

    public Text txtName;
    public Image imgState;

    public Text txtRange;

    public List<GameObject> itemList = new List<GameObject>();

    public override void Init()
    {
        List<ServerInfo> serverList = LoginMgr.Instance.ServerData;
        int count = (serverList.Count + 4) / 5;
        for (int i = 0; i < count; i++)
        {
            GameObject item = Instantiate(Resources.Load<GameObject>("UI/ServerLeftItem"), svLeft.content, false);
            item.GetComponent<ServerLeftItem>().InitInfo(i * 5 + 1, Mathf.Min((i + 1) * 5, serverList.Count));
        }
    }

    public override void ShowMe()
    {
        base.ShowMe();
        int id = LoginMgr.Instance.LoginData.lastServerID;
        if (id <= 0)
        {
            txtName.text = "无";
            imgState.gameObject.SetActive(false);
        }
        else
        {
            ServerInfo serverInfo = LoginMgr.Instance.ServerData[id - 1];
            txtName.text = serverInfo.id + "区 " + serverInfo.name;

            imgState.gameObject.SetActive(true);
            SpriteAtlas atlas = Resources.Load<SpriteAtlas>("Login");
            switch (serverInfo.state)
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

        UpdatePanel(1, 5);
    }

    public void UpdatePanel(int beginIndex, int endIndex)
    {
        txtRange.text = $"服务器 {beginIndex}—{endIndex}";
        foreach (var item in itemList)
        {
            Destroy(item);
        }

        itemList.Clear();

        for (int i = beginIndex; i <= endIndex; i++)
        {
            ServerInfo nowInfo = LoginMgr.Instance.ServerData[i - 1];
            GameObject item = Instantiate(Resources.Load<GameObject>("UI/ServerRightItem"), svRight.content, false);
            ServerRightItem rightItem = item.GetComponent<ServerRightItem>();
            rightItem.InitInfo(nowInfo);

            itemList.Add(item);
        }
    }
}
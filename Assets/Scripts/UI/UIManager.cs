using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private static UIManager _instance = new UIManager();
    public static UIManager Instance => _instance;

    private Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();

    private Transform canvasTransform;

    private UIManager()
    {
        canvasTransform = GameObject.Find("Canvas").transform;
        GameObject.DontDestroyOnLoad(canvasTransform.gameObject);
    }

    public T ShowPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;

        if (panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }

        GameObject panelObj = GameObject.Instantiate(Resources.Load<GameObject>("UI/" + panelName), canvasTransform, false);

        T panel = panelObj.GetComponent<T>();
        panelDic.Add(panelName, panel);

        panel.ShowMe();
        return panel;
    }

    public void HidePanel<T>(bool isFade = true) where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            if (isFade)
            {
                panelDic[panelName].HideMe(() =>
                {
                    GameObject.Destroy(panelDic[panelName].gameObject);
                    panelDic.Remove(panelName);
                });
            }
            else
            {
                GameObject.Destroy(panelDic[panelName].gameObject);
                panelDic.Remove(panelName);
            }
        }
    }

    public T GetPanel<T>() where T : BasePanel
    {
        string panelName = typeof(T).Name;
        if (panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }

        return null;
    }
}
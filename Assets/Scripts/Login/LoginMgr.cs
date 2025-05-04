using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoginMgr
{
    private static LoginMgr _instance = new LoginMgr();
    public static LoginMgr Instance => _instance;

    private LoginData _loginData;
    public LoginData LoginData => _loginData;

    private RegisterData _registerData;
    private RegisterData RegisterData => _registerData;

    private List<ServerInfo> _serverData;
    public List<ServerInfo> ServerData => _serverData;

    private LoginMgr()
    {
        _loginData = JsonMgr.Instance.LoadData<LoginData>("LoginData");
        _registerData = JsonMgr.Instance.LoadData<RegisterData>("RegisterData");
        _serverData = JsonMgr.Instance.LoadData<List<ServerInfo>>("ServerInfo");
    }

    #region LoginData

    public void SaveLoginData()
    {
        JsonMgr.Instance.SaveData(_loginData, "LoginData");
    }

    public void ClearLoginData()
    {
        _loginData.lastServerID = 0;
        _loginData.isAutoLogin = false;
        _loginData.isRemember = false;
    }

    #endregion


    #region RegisterData

    public void SaveRegisterData()
    {
        JsonMgr.Instance.SaveData(_registerData, "RegisterData");
    }

    public bool Register(string username, string password)
    {
        if (_registerData.registerInfo.ContainsKey(username))
        {
            UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("该用户名已被注册");
            return false;
        }

        _registerData.registerInfo.Add(username, password);
        SaveRegisterData();

        return true;
    }


    public bool CheckInfo(string username, string password)
    {
        if (_registerData.registerInfo.ContainsKey(username))
        {
            if (_registerData.registerInfo[username] == password)
            {
                return true;
            }
        }

        return false;
    }

    #endregion
}
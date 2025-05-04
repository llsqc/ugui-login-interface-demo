using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    public Button btnRegister;
    public Button btnSure;

    public InputField inputUsername;
    public InputField inputPassword;

    public Toggle toggleAutoLogin;
    public Toggle toggleRemember;

    public override void Init()
    {
        btnRegister.onClick.AddListener(() =>
        {
            UIManager.Instance.ShowPanel<RegisterPanel>();
            UIManager.Instance.HidePanel<LoginPanel>();
        });

        btnSure.onClick.AddListener(() =>
        {
            if (inputUsername.text.Length < 6 || inputPassword.text.Length < 6)
            {
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("账号和密码需要大于六位");
                return;
            }

            if (LoginMgr.Instance.CheckInfo(inputUsername.text, inputPassword.text))
            {
                LoginMgr.Instance.LoginData.username = inputUsername.text;
                LoginMgr.Instance.LoginData.password = inputPassword.text;
                LoginMgr.Instance.LoginData.isRemember = toggleRemember.isOn;
                LoginMgr.Instance.LoginData.isAutoLogin = toggleAutoLogin.isOn;
                LoginMgr.Instance.SaveLoginData();

                if (LoginMgr.Instance.LoginData.lastServerID <= 0)
                {
                    UIManager.Instance.ShowPanel<ServerListPanel>();
                }
                else
                {
                    UIManager.Instance.ShowPanel<ServerPanel>();
                }

                UIManager.Instance.HidePanel<LoginPanel>();
            }
            else
            {
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("账号或密码错误");
            }
        });

        toggleRemember.onValueChanged.AddListener(isOn =>
        {
            if (!isOn)
            {
                toggleAutoLogin.isOn = false;
            }
        });

        toggleAutoLogin.onValueChanged.AddListener(isOn =>
        {
            if (isOn)
            {
                toggleRemember.isOn = true;
            }
        });
    }

    public override void ShowMe()
    {
        base.ShowMe();
        LoginData loginData = LoginMgr.Instance.LoginData;
        toggleAutoLogin.isOn = loginData.isAutoLogin;
        toggleRemember.isOn = loginData.isRemember;

        inputUsername.text = loginData.username;
        if (toggleRemember.isOn)
        {
            inputPassword.text = loginData.password;
        }

        if (toggleAutoLogin.isOn)
        {
            if (LoginMgr.Instance.CheckInfo(inputUsername.text, inputPassword.text))
            {
                if (LoginMgr.Instance.LoginData.lastServerID <= 0)
                {
                    UIManager.Instance.ShowPanel<ServerListPanel>();
                }
                else
                {
                    UIManager.Instance.ShowPanel<ServerPanel>();
                }

                UIManager.Instance.HidePanel<LoginPanel>(false);
            }
            else
            {
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("账号或密码错误");
            }
        }
    }
}
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
        btnRegister.onClick.AddListener(() => { UIManager.Instance.HidePanel<LoginPanel>(); });

        btnSure.onClick.AddListener(() => { });

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
        }
    }
}
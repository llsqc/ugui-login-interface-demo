using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RegisterPanel : BasePanel
{
    public Button btnCancel;
    public Button btnSure;

    public InputField inputUsername;
    public InputField inputPassword;

    public override void Init()
    {
        btnCancel.onClick.AddListener(() =>
        {
            UIManager.Instance.HidePanel<RegisterPanel>();
            UIManager.Instance.ShowPanel<LoginPanel>();
        });
        btnSure.onClick.AddListener(() =>
        {
            if (inputUsername.text.Length < 6 || inputPassword.text.Length < 6)
            {
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("账号和密码需要大于六位");
                return;
            }

            if (LoginMgr.Instance.Register(inputUsername.text, inputPassword.text))
            {
                LoginPanel loginPanel = UIManager.Instance.ShowPanel<LoginPanel>();
                loginPanel.inputUsername.text = inputUsername.text;
                loginPanel.inputPassword.text = inputPassword.text;

                UIManager.Instance.HidePanel<RegisterPanel>();
            }
            else
            {
                UIManager.Instance.ShowPanel<TipPanel>().ChangeInfo("用户名已存在");

                inputUsername.text = "";
                inputPassword.text = "";
            }
        });
    }
}
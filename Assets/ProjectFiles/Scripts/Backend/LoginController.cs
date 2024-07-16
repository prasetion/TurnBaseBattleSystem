using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;

public class LoginController : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] TMP_InputField usernameField;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] Button loginButton;

    void Start()
    {
        loginButton.onClick.AddListener(() => Login());
    }

    void Login()
    {
        LoginData datas = new LoginData();
        datas.email = usernameField.text;
        datas.password = passwordField.text;

        string jsonBody = JsonUtility.ToJson(datas);
        StartCoroutine(Utilites.PostRequest(Const.LOGIN_URL, jsonBody, FinishLogin));
    }

    private void FinishLogin(UnityWebRequest.Result result, string res)
    {
        if (result == UnityWebRequest.Result.Success)
        {
            Debug.Log("success login");
        }
        else
        {
            Debug.Log("fail login");
        }
    }

    [System.Serializable]
    struct LoginData
    {
        public string email;
        public string password;
    }
}

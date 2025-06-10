using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class BankManager : MonoBehaviour
{
    public TextMeshProUGUI cash;
    public TextMeshProUGUI balance;
    public TextMeshProUGUI name;

    public static BankManager Instance;
    public static BankUI bankUI;
    public UserData currentUser { get; private set; }
    public UserDataManager userDataManager;
    public void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);

        userDataManager = GetComponent<UserDataManager>();

        if (userDataManager != null)
            userDataManager.LoadUserData();
        else
        { Debug.LogError("UserDataManager is not assigned!"); }

        UpdateDisplay();
    }
    public void UpdateDisplay()
    {
        if (currentUser != null)
        {
            name.text = currentUser.userName;
            balance.text = currentUser.balance.ToString("N0");
            cash.text = currentUser.cash.ToString("N0");
        }
    }
    private void OnApplicationQuit()
    {
        userDataManager.SaveUserData();
    }


    public void SetCurrentUser(UserData user)
    {
        currentUser = user;
        UpdateDisplay();
    }
    public void Logout()
    {
        currentUser = null;
        UpdateDisplay(); // 값 초기화
    }

}

using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI cash;
    public TextMeshProUGUI balance;
    public TextMeshProUGUI name;

    public GameObject notEnough;

    public static GameManager Instance;
    public UserData userData;

    private string savePath;
    public void Awake()
    {

        userData = new UserData();


        if (Instance == null) Instance = this;
        else Destroy(gameObject);


        savePath = Path.Combine(Application.persistentDataPath, "userdata.json");

        LoadUserData(); // 시작 시 로딩
        Refresh();
    }
    public void Refresh()
    {
        if (userData != null)
        {
            name.text = userData.userName;
            balance.text = userData.balance.ToString("N0");
            cash.text = userData.cash.ToString("N0");
        }
    }
    public void SaveFromUI()
    {
        if (userData != null)
        {
            userData.userName = name.text;
            userData.cash = int.Parse(cash.text.Replace(",", ""));
            userData.balance = int.Parse(balance.text.Replace(",", ""));
        }
    }
    public void OnNotEnough()
    {
        notEnough.SetActive(true);
    }
    public void offNotEnough()
    {
        notEnough.SetActive(false);
    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userData, true);
        File.WriteAllText(savePath, json);
        Debug.Log("UserData 저장됨: " + savePath);
    }

    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userData = JsonUtility.FromJson<UserData>(json);
            Debug.Log("UserData 불러옴");
        }
        else
        {
            userData = new UserData(); // 없으면 초기값 생성
            Debug.Log("UserData 없음 → 새로 생성");
        }
    }
    private void OnApplicationQuit()
    {
        SaveUserData();
    }
}

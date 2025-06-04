using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UserDataDisplay : MonoBehaviour
{
    public UserData userData;

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI balanceText;
    public TextMeshProUGUI cashText;

    void Start()
    {
        if (userData != null)
        {
            nameText.text = userData.userName;
            balanceText.text = userData.balance.ToString("N0"); // 100,000 형식
            cashText.text = userData.cash.ToString("N0");
        }
    }
}

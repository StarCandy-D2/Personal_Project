using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BankUI : MonoBehaviour
{
    public UserData userData;
    public GameManager gameManager;

    public GameObject buttons;
    public GameObject depositUI;
    public GameObject withdrawUI;
    public TMP_InputField depositcostom;
    public TMP_InputField withdrawcostom;

    public void Start()
    {
        userData = gameManager.userData;
        gameManager.Refresh();
    }
    public void Ondeposit()
    {
        buttons.SetActive(false);
        depositUI.SetActive(true);
    }
    public void Deposit10000()
    {
        if (userData.cash >= 10000)
        {
            userData.cash -= 10000;
            userData.balance += 10000;
            gameManager.Refresh();
        }
        else { gameManager.OnNotEnough(); }
    }

    public void Deposit30000()
    {
        if (userData.cash >= 30000)
        {
            userData.cash -= 30000;
            userData.balance += 30000;
            gameManager.Refresh();

        }
        else { gameManager.OnNotEnough(); }
    }

    public void Deposit50000()
    {
        if (userData.cash >= 50000)
        {
            userData.cash -= 50000;
            userData.balance += 50000;
            gameManager.Refresh();

        }
        else { gameManager.OnNotEnough(); }
    }
    public void CostomDeposit()
    {
        if (int.TryParse(depositcostom.text, out int value))
        {
            if (userData.cash >= value)
            {
                userData.cash -= value;
                userData.balance += value;
                gameManager.Refresh();

            }
            else { gameManager.OnNotEnough(); }
        }

        depositcostom.text = "";
    }
    public void OffDeposit()
    {
        buttons.SetActive(true);
        depositUI.SetActive(false);
    }
    public void OnWithDraw()
    {
        buttons.SetActive(false);
        withdrawUI.SetActive(true);
    }
    public void WithDraw10000()
    {
        if (userData.balance >= 10000)
        {
            userData.cash += 10000;
            userData.balance -= 10000;
            gameManager.Refresh();

        }
        else { gameManager.OnNotEnough(); }
    }

    public void WithDraw30000()
    {
        if (userData.balance >= 30000)
        {
            userData.cash += 30000;
            userData.balance -= 30000;
            gameManager.Refresh();

        }
        else { gameManager.OnNotEnough(); }
    }

    public void WithDraw50000()
    {
        if (userData.balance >= 50000)
        {
            userData.cash += 50000;
            userData.balance -= 50000;
            gameManager.Refresh();

        }
        else { gameManager.OnNotEnough(); }
    }

    public void CostomWithDraw()
    {
        if (int.TryParse(withdrawcostom.text, out int value))
        {
            if (userData.balance >= value)
            {
                userData.cash += value;
                userData.balance -= value;
                gameManager.Refresh();

            }
            else { gameManager.OnNotEnough(); }
        }

        withdrawcostom.text = "";
    }
    public void OffWithDraw()
    {
        buttons.SetActive(true);
        withdrawUI.SetActive(false);
    }
}

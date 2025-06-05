using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BankUI : MonoBehaviour
{
    public GameManager gameManager;
    public UserDataManager userDataManager;

    public GameObject notEnough;
    public GameObject buttons;
    public GameObject depositUI;
    public GameObject withdrawUI;
    public GameObject popupBank;
    public GameObject popupLogin;
    public GameObject popupSignUp;
    public GameObject popupWrongLogin;
    public GameObject popupWrongSignUp;
    public GameObject popupTransferSuccess;
    public GameObject popupTransferFailed;
    public GameObject transferUI;

    public TMP_InputField enterID;
    public TMP_InputField enterPW;
    public TMP_InputField depositcustom;
    public TMP_InputField withdrawcustom;
    public TMP_InputField signupID;
    public TMP_InputField signupPW;
    public TMP_InputField signupName;
    public TMP_InputField signupPWConfirm;
    public TMP_InputField transferTargetID;
    public TMP_InputField transferAmount;

    public void Start()
    {
        GameManager.Instance.UpdateDisplay();
    }
    public void Ondeposit()
    {
        buttons.SetActive(false);
        depositUI.SetActive(true);
    }
    public void Deposit10000()
    {
        if (GameManager.Instance.currentUser.cash >= 10000)
        {
            GameManager.Instance.currentUser.cash -= 10000;
            GameManager.Instance.currentUser.balance += 10000;
            GameManager.Instance.UpdateDisplay();
        }
        else { OnNotEnough(); }
    }

    public void Deposit30000()
    {
        if (GameManager.Instance.currentUser.cash >= 30000)
        {
            GameManager.Instance.currentUser.cash -= 30000;
            GameManager.Instance.currentUser.balance += 30000;
            GameManager.Instance.UpdateDisplay();  

        }
        else { OnNotEnough(); }
    }

    public void Deposit50000()
    {
        if (GameManager.Instance.currentUser.cash >= 50000)
        {
            GameManager.Instance.currentUser.cash -= 50000;
            GameManager.Instance.currentUser.balance += 50000;
            GameManager.Instance.UpdateDisplay();

        }
        else { OnNotEnough(); }
    }
    public void CustomDeposit()
    {
        if (int.TryParse(depositcustom.text, out int value) && value > 0)
        {
            if (GameManager.Instance.currentUser.cash >= value)
            {
                GameManager.Instance.currentUser.cash -= value;
                GameManager.Instance.currentUser.balance += value;
                GameManager.Instance.UpdateDisplay();
            }
            else
            {
                OnNotEnough();
            }
        }
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
        if (GameManager.Instance.currentUser.balance >= 10000)
        {
            GameManager.Instance.currentUser.cash += 10000;
            GameManager.Instance.currentUser.balance -= 10000;
            GameManager.Instance.UpdateDisplay();

        }
        else { OnNotEnough(); }
    }

    public void WithDraw30000()
    {
        if (GameManager.Instance.currentUser.balance >= 30000)
        {
            GameManager.Instance.currentUser.cash += 30000;
            GameManager.Instance.currentUser.balance -= 30000;
            GameManager.Instance.UpdateDisplay();

        }
        else { OnNotEnough(); }
    }

    public void WithDraw50000()
    {
        if (GameManager.Instance.currentUser.balance >= 50000)
        {
            GameManager.Instance.currentUser.cash += 50000;
            GameManager.Instance.currentUser.balance -= 50000;
            GameManager.Instance.UpdateDisplay();

        }
        else { OnNotEnough(); }
    }

    public void CustomWithDraw()
    {
        if (int.TryParse(withdrawcustom.text, out int value) && value > 0)
        {
            if (GameManager.Instance.currentUser.balance >= value)
            {
                GameManager.Instance.currentUser.cash += value;
                GameManager.Instance.currentUser.balance -= value;
                GameManager.Instance.UpdateDisplay();
            }
            else
            {
                OnNotEnough();
            }
        }

        withdrawcustom.text = "";
    }
    public void OffWithDraw()
    {
        buttons.SetActive(true);
        withdrawUI.SetActive(false);
    }
    public void SaveFromUI()
    {
        if (GameManager.Instance.currentUser != null)
        {
            GameManager.Instance.currentUser.userName = gameManager.name.text;
            GameManager.Instance.currentUser.cash = int.Parse(gameManager.cash.text.Replace(",", ""));
            GameManager.Instance.currentUser.balance = int.Parse(gameManager.balance.text.Replace(",", ""));
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

    public void Login()
    {
        string id = enterID.text.Trim();
        string pw = enterPW.text;

        if (userDataManager.ValidateLogin(id, pw, out UserData loggedInUser))
        {
            GameManager.Instance.SetCurrentUser(loggedInUser); // 아래에 따로 설명
            popupLogin.SetActive(false);
            popupBank.SetActive(true);
        }
        else
        {
            popupWrongLogin.SetActive(true);
        }
        enterID.text = "";
        enterPW.text = "";
    }
    public void BacktoLogin()
    {
        popupWrongLogin.SetActive(false);
        popupLogin.SetActive(true);
        popupSignUp.SetActive(false);
    }
    public void GotoSignUP()
    {
        popupSignUp.SetActive(true);
        popupLogin.SetActive(false);
    }
    public void SignUp()
    {
        string id = signupID.text.Trim();
        string name = signupName.text.Trim();
        string pw = signupPW.text;
        string pwConfirm = signupPWConfirm.text;

        if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(pw))
        {
            Debug.LogWarning("빈 칸이 있습니다.");
            WrongSignUP();
            return;
        }

        if (pw != pwConfirm)
        {
            Debug.LogWarning("비밀번호가 일치하지 않습니다.");
            WrongSignUP();
            return;
        }

        if (userDataManager.IsIDTaken(id))
        {
            Debug.LogWarning("이미 사용 중인 ID입니다.");
            WrongSignUP();

            return;
        }

        UserData newUser = new UserData
        {
            userID = id,
            userName = name,
            userPassword = pw,
            balance = 0,
            cash = 200000
        };

        userDataManager.userDatabase.users.Add(newUser);
        userDataManager.SaveUserData();
        signupID.text = "";
        signupName.text = "";
        signupPW.text = "";
        signupPWConfirm.text = "";

        popupSignUp.SetActive(false);
        popupLogin.SetActive(true);
    }
    public void WrongSignUP()
    {
        popupSignUp.SetActive(false);
        popupWrongSignUp.SetActive(true);
    }
    public void BacktoSignUP()
    {
        popupSignUp.SetActive(true);
        popupWrongSignUp.SetActive(false);
    }
    public void LogoutButtonPressed()
    {
        GameManager.Instance.Logout();

        popupBank.SetActive(false);
        popupLogin.SetActive(true);

        enterID.text = "";
        enterPW.text = "";
    }
    public void TransferUI()
    {
        buttons.SetActive(false);
        transferUI.SetActive(true);
    }
    public void Transfer()
    {
        string targetID = transferTargetID.text.Trim();
        string amountStr = transferAmount.text.Trim();

        if (!int.TryParse(amountStr, out int amount) || amount <= 0)
        {
            Debug.LogWarning("송금 금액이 유효하지 않습니다.");
            popupTransferFailed.SetActive(true);
            return;
        }

        UserData sender = GameManager.Instance.currentUser;
        if (sender.balance < amount)
        {
            Debug.LogWarning("잔액 부족");
            popupTransferFailed.SetActive(true);
            return;
        }

        UserData receiver = userDataManager.GetUserByID(targetID);
        if (receiver == null)
        {
            Debug.LogWarning("수신자 ID가 존재하지 않습니다.");
            popupTransferFailed.SetActive(true);
            return;
        }

        // 송금 수행
        sender.balance -= amount;
        receiver.balance += amount;

        // 저장 및 UI 반영
        userDataManager.SaveUserData();
        GameManager.Instance.UpdateDisplay();

        popupTransferSuccess.SetActive(true);
        transferTargetID.text = "";
        transferAmount.text = "";
    }
    public void CloseTransferPopup()
    {
        popupTransferFailed.SetActive(false);
        popupTransferSuccess.SetActive(false);
        transferUI.SetActive(true);
    }
    public void OffTransferUI()
    {
        buttons.SetActive(true);
        transferUI.SetActive(false);
    }
}

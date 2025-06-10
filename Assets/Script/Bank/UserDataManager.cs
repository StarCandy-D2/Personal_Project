using System.IO;
using UnityEngine;

public class UserDataManager : MonoBehaviour
{
    public UserDatabase userDatabase = new UserDatabase();
    private string savePath;

    private void Awake()
    {
        savePath = Path.Combine(Application.persistentDataPath, "userdata.json");
    }


    public void LoadUserData()
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            userDatabase = JsonUtility.FromJson<UserDatabase>(json);
            Debug.Log("UserDatabase 불러옴");
        }
        else
        {
            userDatabase = new UserDatabase();
            Debug.Log("UserDatabase 없음 → 새로 생성");
        }
    }

    public void SaveUserData()
    {
        string json = JsonUtility.ToJson(userDatabase, true);
        File.WriteAllText(savePath, json);
        Debug.Log("UserDatabase 저장됨");
    }
    public UserData GetUserByID(string id)
    {
        return userDatabase.users.Find(u => u.userID == id);
    }

    public bool IsIDTaken(string id)
    {
        return GetUserByID(id) != null;
    }

    public bool ValidateLogin(string id, string pw, out UserData foundUser)
    {
        foundUser = userDatabase.users.Find(u => u.userID == id && u.userPassword == pw);
        return foundUser != null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewUserData", menuName = "User/User Data")]
public class UserData : ScriptableObject
{
    public string userName = "D";
    public int balance = 100000;
    public int cash = 80000;
}


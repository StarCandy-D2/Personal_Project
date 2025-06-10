using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public Character Player { get; private set; }

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    private void Start()
    {
        SetData();
    }

    public void SetData()
    {
        // 캐릭터 생성
        Player = new Character("용사", 10, 80f, 30, 20, 120, 0.15f);

        // 아이템 생성 및 인벤토리 채우기
        Sprite potionIcon = Resources.Load<Sprite>("Sprites/Potion");
        Sprite swordIcon = Resources.Load<Sprite>("Sprites/Sword");
        Sprite shieldIcon = Resources.Load<Sprite>("Sprites/Shield");

        Player.Inventory.Add(new Item("포션", potionIcon, 5));
        Player.Inventory.Add(new Item("장검", swordIcon, 1));
        Player.Inventory.Add(new Item("방패", shieldIcon, 1));

        // UI에 데이터 반영
        UIManager.Instance.MainMenu.OpenMainMenu();
        UIManager.Instance.StatusUI.SetCharacterInfo(Player);
        UIManager.Instance.InventoryUI.SetInventory(Player.Inventory);
    }
}


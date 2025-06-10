using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private UIMainMenu mainMenu;
    [SerializeField] private UIStatus statusUI;
    [SerializeField] private UIInventory inventoryUI;

    public UIMainMenu MainMenu => mainMenu;
    public UIStatus StatusUI => statusUI;
    public UIInventory InventoryUI => inventoryUI;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowOnlyUI(GameObject ui)
    {
        mainMenu.gameObject.SetActive(false);
        statusUI.gameObject.SetActive(false);
        inventoryUI.gameObject.SetActive(false);

        ui.SetActive(true);
    }
}

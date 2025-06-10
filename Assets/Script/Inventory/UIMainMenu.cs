using UnityEngine;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private Button statusButton;
    [SerializeField] private Button inventoryButton;

    private void Start()
    {
        statusButton.onClick.AddListener(OpenStatus);
        inventoryButton.onClick.AddListener(OpenInventory);
    }

    public void OpenMainMenu()
    {
        UIManager.Instance.ShowOnlyUI(gameObject);
    }

    private void OpenStatus()
    {
        UIManager.Instance.ShowOnlyUI(UIManager.Instance.StatusUI.gameObject);
        UIManager.Instance.StatusUI.SetCharacterInfo(GameManager.Instance.Player);
    }

    private void OpenInventory()
    {
        UIManager.Instance.ShowOnlyUI(UIManager.Instance.InventoryUI.gameObject);
        UIManager.Instance.InventoryUI.SetInventory(GameManager.Instance.Player.Inventory);
    }
}

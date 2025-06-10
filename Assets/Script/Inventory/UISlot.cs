using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class UISlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI amountText;

    private Item item;

    public void SetItem(Item newItem)
    {
        item = newItem;

        if (item != null)
        {
            icon.sprite = item.icon;
            icon.enabled = true;
            amountText.text = item.amount > 1 ? $"x{item.amount}" : "";
        }
        else
        {
            icon.enabled = false;
            amountText.text = "";
        }
    }
}

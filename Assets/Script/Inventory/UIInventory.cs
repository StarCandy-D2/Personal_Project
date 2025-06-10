using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotParent;

    private List<UISlot> slots = new List<UISlot>();

    public void OpenInventory()
    {
        gameObject.SetActive(true);
    }

    public void SetInventory(List<Item> items)
    {
        Debug.Log($"[UIInventory] SetInventory called, item count: {items.Count}");
        RefreshInventoryUI(items);
    }
    private void RefreshInventoryUI(List<Item> items)
    {
        Debug.Log($"[UIInventory] Refreshing UI with {items.Count} items");

        foreach (var slot in slots)
            Destroy(slot.gameObject);
        slots.Clear();

        foreach (var item in items)
        {
            GameObject obj = Instantiate(slotPrefab, slotParent);
            if (obj.TryGetComponent(out UISlot slot))
            {
                slot.SetItem(item);
                slots.Add(slot);
            }
            else
            {
                Debug.LogWarning("프리팹에 UISlot 스크립트가 없음!");
            }
        }
    }

}

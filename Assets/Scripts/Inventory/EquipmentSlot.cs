using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : MonoBehaviour
{
    [SerializeField] private Image defaultIcon;
    [SerializeField] private Image itemIcon;
    public EquipmentSlotType type;

    private ItemData itemData;

    public void SetItem(ItemData data)
    {
        itemData = data;
        itemData.icon = data.icon;
        itemIcon.sprite = itemData.icon;
        itemIcon.enabled = true;
        defaultIcon.enabled = false;
    }

    public void Unequip()
    {
        if (InventoryManager.Instance.GetEmptyInventorySlot() != -1)
        {
            InventoryManager.Instance.AddItem(itemData.id);
            InventoryManager.Instance.player.RemoveAttributes(itemData.attributes);

            itemIcon.enabled = false;
            defaultIcon.enabled = true;
            itemIcon.sprite = null;
            itemData = null;
        }
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}

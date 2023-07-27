using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private ItemData itemData;
    public Image itemIcon;

    public void SetItem(ItemData data)
    {
        itemData = data;
        itemIcon.sprite = data.icon;
        itemIcon.enabled = true;
    }

    public void UseItem()
    {
        if (itemData.type == ItemType.Equipabble && InventoryManager.Instance.GetEquipmentSlot(itemData.slotType) == -1){
            Debug.Log("No");
        }
        else
        {
            InventoryManager.Instance.UseItem(itemData);
            itemIcon.sprite = null;
            itemIcon.enabled = false;
            itemData = null;
        }
    }

    public bool HasItem()
    {
        return itemData != null;
    }
}

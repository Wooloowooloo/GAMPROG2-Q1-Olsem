using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item : Interactable
{
    public override void Interact()
    {
        InventoryManager.Instance.AddItem(itemdata.id);
        Destroy(gameObject);
    }
}

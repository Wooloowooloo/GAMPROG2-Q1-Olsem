using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Player player;
    //For now, this will store information of the Items that can be added to the inventory
    public List<ItemData> itemDatabase;

    //Store all the inventory slots in the scene here
    public List<InventorySlot> inventorySlots;

    //Store all the equipment slots in the scene here
    public List<EquipmentSlot> equipmentSlots;

    //Singleton implementation. Do not change anything within this region.
    #region SingletonImplementation
    private static InventoryManager instance = null;
    public static InventoryManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<InventoryManager>();
                if (instance == null)
                {
                    GameObject go = new GameObject();
                    go.name = "Inventory";
                    instance = go.AddComponent<InventoryManager>();
                    DontDestroyOnLoad(go);
                }
            }
            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public Key key;

    public void UseItem(ItemData data)
    {
        if(data.type == ItemType.Consumable)
        {
            Debug.Log("used consumable");
            player.AddAttributes(data.attributes);
        }

        if (data.type == ItemType.Equipabble)
        {
            Debug.Log("equipped something");
            equipmentSlots[GetEquipmentSlot(data.slotType)].SetItem(data);
            player.AddAttributes(data.attributes);
        }

        if(data.type == ItemType.Key)
        {
            Debug.Log("Opened the door");
            key.OpenDoor();
        }
    }

   
    public void AddItem(string itemID)
    {
        Debug.Log(itemID);
        int putHere = -1;
        int freeSlot = GetEmptyInventorySlot();

        for (int i = 0; i < itemDatabase.Count; i++)
        {
            if (itemDatabase[i].id == itemID)
            {
                putHere = i;
                break;
            }
        }

        inventorySlots[freeSlot].SetItem(itemDatabase[putHere]);
    }

    public int GetEmptyInventorySlot()
    {
        int freeSlot = -1;

        for (int i = 0; i < inventorySlots.Count; i++)
        {
            if (!inventorySlots[i].HasItem())
            {
                freeSlot = i;
                break;
            }
        }

        return freeSlot;
    }

    public int GetEquipmentSlot(EquipmentSlotType type)
    {
        int equippableSlot = -1;

        for (int i = 0; i < equipmentSlots.Count; i++)
        {
            if (equipmentSlots[i].type == type)
            {
                if (!equipmentSlots[i].HasItem())
                {
                    equippableSlot = i;
                    break;
                }
            }
        }

        return equippableSlot;
    }
}

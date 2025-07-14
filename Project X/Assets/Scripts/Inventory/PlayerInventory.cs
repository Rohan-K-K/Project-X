using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "PlayerInventory", menuName = "Scriptable Objects/PlayerInventory")]
public class PlayerInventory : ScriptableObject
{
    public ItemData equippedItem;
    public List<ItemData> items = new();

    public void AddToInventory(ItemData itemToAdd)
    {
        items.Add(itemToAdd);
    }

    public void EquipItem(ItemData itemToEquip)
    {
        if (!items.Contains(itemToEquip))
        {
            Debug.Log("Item not found in inventory");
            return;
        }
        else if (itemToEquip == equippedItem)
        {
            Debug.Log("Item already equipped");
            return;
        }
        else
        {
            equippedItem = itemToEquip;
        }
    }
}

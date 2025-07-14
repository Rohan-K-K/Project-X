using System.Collections.Generic;
using UnityEngine;

public class LootboxManager : MonoBehaviour
{
    public List<ItemData> itemsInChest;
    public PlayerInventory inventory;

    public void OpenLootbox()
    {
        //TODO: play chest open animation and any sound effects
        foreach (var i in itemsInChest)
        {
            if (!inventory.items.Contains(i))
            {
                inventory.AddToInventory(i);
            }
        }
        gameObject.SetActive(false);
    }
}

using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    //Singleton instance itself to mainting it alive everywhere anywhere
    public static InventorySystem Instance { get; private set; }

    [SerializeField] private List<ItemInstance> inventory = new List<ItemInstance>();

    void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData itemData, Condition condition)
    {
        ItemInstance newItem = new ItemInstance(itemData, condition);
        inventory.Add(newItem);
    }

    public void RemoveItem(ItemInstance item)
    {
        if(!inventory.Contains(item))
        {
            Debug.LogWarning("RemoveItem: item does not exist in inventory -> " + item.itemData.itemName);
            return;
        }
        inventory.Remove(item);
    }

    public List<ItemInstance> GetAllItems()
    {
        return inventory;
    }

    public List<ItemInstance> GetItemsByRarity(Rarity rarity)
    {
        return inventory.FindAll(item => item.itemData.rarity == rarity);
    }

    public int GetQuantity(ItemData itemData)
    {
        return inventory.FindAll(item => item.itemData == itemData).Count;
    }
}

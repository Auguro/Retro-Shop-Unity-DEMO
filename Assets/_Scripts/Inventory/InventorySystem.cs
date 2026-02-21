using System.Collections.Generic;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    //Singleton instance itself to mainting it alive everywhere anywhere
    public static InventorySystem Instance { get; private set; }

    [SerializeField]
    private Dictionary<ItemData, int> inventory = new Dictionary<ItemData, int>();

    void Awake()
    {
        Instance = this;
    }

    public void AddItem(ItemData itemData, int quantity)
    {
        //verify if already exists, if yes then just add the value
        if(inventory.ContainsKey(itemData)){
            inventory[itemData] += quantity;
        }
        //if not, add in the dicionary
        else
        {
            inventory.Add(itemData, quantity);
        }
    }

    public void RemoveItem(ItemData itemData, int quantity)
    {
        //Error handling 
        if(!inventory.ContainsKey(itemData))
        {
            Debug.LogWarning("RemoveItem: item does not exist in inventory -> " + itemData.itemName);
            return;
        }
        if(inventory[itemData] < quantity)
        {
            Debug.LogWarning("RemoveItem: quantity requested is greater than stock -> " + itemData.itemName);
            return;
        }

        //code
        if(inventory[itemData] == quantity)
        {
            inventory.Remove(itemData);
        }
        else
        {
            inventory[itemData] -= quantity;
        }
        
    }

    public int GetQuantity(ItemData itemData)
    {
        if(!inventory.ContainsKey(itemData))
        {
            Debug.LogWarning("GetQuantity: item does not exist in inventory -> " + itemData.itemName);
            return -1;
        }
        return inventory[itemData];
    }
}

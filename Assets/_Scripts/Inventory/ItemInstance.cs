using UnityEngine;

public class ItemInstance
{
    public ItemData itemData;
    [SerializeField] public Condition condition;
    [SerializeField] public float finalPrice;

    public ItemInstance(ItemData data, Condition cond)
    {
        itemData = data;
        condition = cond;
        finalPrice = itemData.basePrice;
    }
}
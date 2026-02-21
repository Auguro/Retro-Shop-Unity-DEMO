using UnityEngine;

public enum Category
{
    Game,
    Console,
    Acessory
}

public enum Era
{
    New,
    Retro
}

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Legendary
}

[CreateAssetMenu(fileName = "NewItem", menuName = "Retro Vault/Item")]
public class ItemData : ScriptableObject
{
    [SerializeField]
    public string itemName;
    [SerializeField]
    public Category category;
    [SerializeField]
    public Era era;
    [SerializeField]
    public Rarity rarity;
    [SerializeField]
    public float basePrice;
    [SerializeField]
    public float acquireCost;
    [SerializeField]
    public bool isExclusive;
    [SerializeField]
    public int exclusiveRivalID;
    [SerializeField]
    public bool canBeMuseum;
    [SerializeField]
    public float reputationBonus;
}

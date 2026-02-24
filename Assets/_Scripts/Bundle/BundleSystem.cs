using System.Collections.Generic;
using UnityEngine;

public class BundleSystem : MonoBehaviour
{
    public static BundleSystem Instance { get; private set; }

    private List<ItemData> allItems = new List<ItemData>();

    void Awake()
    {
        Instance = this;
        allItems = new List<ItemData>(Resources.LoadAll<ItemData>("Items"));
        Debug.Log($"BundleSystem: {allItems.Count} items carregados.");
    }

    public List<ItemInstance> OpenBundle(BundleData bundle)
    {
        List<ItemInstance> result = new List<ItemInstance>();

        for (int i = 0; i < bundle.itemCount; i++)
        {
            Rarity rarity = RollRarity(bundle);
            ItemData item = GetRandomItemByRarity(rarity);

            if (item != null)
                result.Add(new ItemInstance(item, bundle.condition));
        }

        return result;
    }

    private Rarity RollRarity(BundleData bundle)
    {
        float roll = Random.Range(0f, 1f);

        if (roll < bundle.chanceLegendary) return Rarity.Legendary;
        if (roll < bundle.chanceLegendary + bundle.chanceEpic) return Rarity.Epic;
        if (roll < bundle.chanceLegendary + bundle.chanceEpic + bundle.chanceRare) return Rarity.Rare;
        return Rarity.Common;
    }

    private ItemData GetRandomItemByRarity(Rarity rarity)
    {
        List<ItemData> filtered = allItems.FindAll(i => i.rarity == rarity);

        if (filtered.Count == 0)
        {
            Debug.LogWarning($"BundleSystem: nenhum item encontrado com raridade {rarity}");
            return null;
        }

        return filtered[Random.Range(0, filtered.Count)];
    }
}
using UnityEngine;

[CreateAssetMenu(fileName = "NewBundle", menuName = "Retro Vault/Bundle")]
public class BundleData : ScriptableObject
{
    public string bundleName;
    public float cost;
    public int itemCount;
    public Condition condition;

    [Range(0f, 1f)] public float chanceRare = 0.08f;
    [Range(0f, 1f)] public float chanceEpic = 0.01f;
    [Range(0f, 1f)] public float chanceLegendary = 0f;
}
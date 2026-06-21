using UnityEngine;

[CreateAssetMenu]
public class InventoryInfo : ScriptableObject
{
    public enum InventoryObjectType
    {
        Healt,
        Magic,
        Ammo,
    }

    public enum UsageType
    {
        Direct,
        InInventory,
    }

    public InventoryObjectType type;
    public UsageType usage;
    public float recovery = 1f;

}

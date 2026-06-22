using UnityEngine;
using UnityEngine.Events;

public class PlayerCollect : MonoBehaviour
{

    [SerializeField] GameObject inventoryItemUIPrefab;
    [SerializeField] Transform itemsParent;

    [SerializeField] InventoryInfo[] startingObjects;

    public UnityEvent <CollectableObject> OnCollectedObjectDirectUsage;

    Inventory inventory;

    private void Awake()
    {
        inventory = GetComponent<Inventory>();
        for (int i = 0; i < startingObjects.Length; i++)
        {
            AddObjectToInventory(startingObjects[i]);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CollectableObject collectable = collision.GetComponent<CollectableObject>();
        if (collectable != null)
        {
            switch (collectable.inventoryInfo.usage)
            {
                case InventoryInfo.UsageType.Direct:
                    OnCollectedObjectDirectUsage.Invoke(collectable);
                    break;
                case InventoryInfo.UsageType.InInventory:
                    {
                        AddObjectToInventory(collectable.inventoryInfo);
                    }
                    break;
            }

            collectable.NotyfyCollected();
        }
    }

    private void AddObjectToInventory(InventoryInfo inventoryInfo)
    {
        GameObject newItem = Instantiate(inventoryItemUIPrefab, itemsParent);
        newItem.GetComponent<InventoryItem>().Initialize(inventory, inventoryInfo);
    }
}

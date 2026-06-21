using UnityEngine;
using UnityEngine.Events;

public class PlayerCollect : MonoBehaviour
{

    [SerializeField] GameObject inventoryItemUIPrefab;
    [SerializeField] Transform itemsParent;

    public UnityEvent <CollectableObject> OnCollectedObjectDirectUsage;

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
                        GameObject newItem = Instantiate(inventoryItemUIPrefab, itemsParent);
                        newItem.GetComponent<InventoryItem>().Initialize(collectable.inventoryInfo);
                    }
                    break;
            }

            collectable.NotyfyCollected();
        }
    }
}

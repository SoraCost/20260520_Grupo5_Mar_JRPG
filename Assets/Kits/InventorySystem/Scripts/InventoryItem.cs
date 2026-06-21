using System;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItem : MonoBehaviour
{

    [Header("UI Controls")]
    [SerializeField] Image image;
    [SerializeField] Button useButton;
    [SerializeField] Button discardButton;

    InventoryInfo inventoryInfo;

    private void OnEnable()
    {
        useButton.onClick.AddListener(OnUse);
        discardButton.onClick.AddListener(OnDiscard);
    }

    private void OnDisable()
    {
        useButton.onClick.RemoveListener(OnUse);
        discardButton.onClick.RemoveListener(OnDiscard);
    }

    private void OnUse()
    {
        Debug.Log("Using object", this);
    }

    private void OnDiscard()
    {
        Destroy(gameObject);
    }

    public void Initialize(InventoryInfo inventoryInfo)
    {
        this.inventoryInfo = inventoryInfo;
        //?????;
    }    

}

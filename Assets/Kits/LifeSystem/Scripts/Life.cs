using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;

public class Life : MonoBehaviour
{
    [SerializeField] float startLife = 1f;
    [SerializeField] float damagePerHit = 0.3f;

    public UnityEvent<float, float> onLifeChanged;
    public UnityEvent<float> onLifeDepleted;

    HurtCollider hurtCollider;
    PlayerCollect playerCollect;
    Inventory inventory;

    float currentLife;

    [SerializeField] bool debugReceiveDamage;

    [SerializeField] GameObject endingText;
    [SerializeField] GameObject resetButton;
    private void OnValidate()
    {
        if (debugReceiveDamage)
        {
            debugReceiveDamage = false;
            OnHitReceived();
        }
    }

    private void Awake()
    {
        hurtCollider = GetComponent<HurtCollider>();
        currentLife = startLife;
        playerCollect = GetComponent<PlayerCollect>();
        inventory = GetComponent<Inventory>();
        endingText.SetActive(false);
        resetButton.SetActive(false);
    }

    private void OnEnable()
    {
        hurtCollider.onHitReceived.AddListener(OnHitReceived);
        //Restart();
        playerCollect?.OnCollectedObjectDirectUsage.AddListener(OnCollectedObject);
        inventory?.onObjectUsed.AddListener(OnObjectUsed);
    }

    private void OnDisable()
    {
        hurtCollider.onHitReceived.RemoveListener(OnHitReceived);
        playerCollect?.OnCollectedObjectDirectUsage.RemoveListener(OnCollectedObject);
        inventory?.onObjectUsed.RemoveListener(OnObjectUsed);
    }

    private void OnHitReceived()
    {
        if (currentLife > 0)
        {
            currentLife -= damagePerHit;
            onLifeChanged.Invoke(currentLife, startLife);
            if (currentLife <= 0f)
            {
                currentLife = 0f;
                onLifeDepleted.Invoke(startLife);
            }

        } else
        {   
            
            
            endingText.SetActive(true);        
            resetButton.SetActive(true);
            resetButton.GetComponentInChildren<TMP_Text>().text = "Reset GAME";
            Destroy(gameObject);
        }
    }

    internal void Restart()
    {
        currentLife = startLife;
        onLifeChanged.Invoke(currentLife, startLife);
    }

    private void OnCollectedObject(CollectableObject collectable)
    {
        InventoryInfo info = collectable.inventoryInfo;
        UseInventoryInfo(info);
    }

    private void OnObjectUsed(InventoryInfo info)
    {
        UseInventoryInfo(info);
    }

    private void UseInventoryInfo(InventoryInfo info)
    {
        currentLife += info.recovery;
        Debug.Log("Revisar limite de recuperacion");
        onLifeChanged.Invoke(currentLife, startLife);
    }
}

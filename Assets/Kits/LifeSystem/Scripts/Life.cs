using System;
using UnityEngine;
using UnityEngine.Events;
public class Life : MonoBehaviour
{
    [SerializeField] float startLife = 1f;
    [SerializeField] float damagePerHit = 0.3f;

    public UnityEvent<float, float> onLifeChanged;
    public UnityEvent<float> onLifeDepleted;

    HurtCollider hurtCollider;
    PlayerCollect playerCollect;

    float currentLife;

    [SerializeField] bool debugReceiveDamage;
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
    }

    private void OnEnable()
    {
        hurtCollider.onHitReceived.AddListener(OnHitReceived);
        Restart();
        playerCollect?.OnCollectedObjectDirectUsage.AddListener(OnCollectedObject);
    }

    private void OnDisable()
    {
        hurtCollider.onHitReceived.RemoveListener(OnHitReceived);
        playerCollect?.OnCollectedObjectDirectUsage.RemoveListener(OnCollectedObject);
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

        }
    }

    internal void Restart()
    {
        currentLife = startLife;
        onLifeChanged.Invoke(currentLife, startLife);
    }


    private void OnCollectedObject(CollectableObject collectable)
    {
        if (
            (collectable.inventoryInfo.type == InventoryInfo.InventoryObjectType.Healt) &&
            (collectable.inventoryInfo.usage == InventoryInfo.UsageType.Direct)
            )
        {
            currentLife += collectable.inventoryInfo.recovery;
            onLifeChanged.Invoke(currentLife, startLife);
        }
    }


}

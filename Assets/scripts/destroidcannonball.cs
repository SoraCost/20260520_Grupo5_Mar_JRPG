using UnityEngine;

public class destroidcannonball : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 void Awake()
    {
        Destroy(gameObject,10f);
    }
}

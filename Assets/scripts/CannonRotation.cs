using UnityEngine;
using UnityEngine.InputSystem;

public class CannonRotation : MonoBehaviour
{
   [SerializeField] float angularspeed=360f;
   Rigidbody2D rb;
    
    void Awake()
    {
       rb=GetComponent<Rigidbody2D>(); 
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.aKey.isPressed)
        {
            rb.angularVelocity=angularspeed;
        }
        else if(Keyboard.current.dKey.isPressed)
        {
            rb.angularVelocity=-angularspeed;
        }
        else
        {
            rb.angularVelocity=0f;
        }
    }
}

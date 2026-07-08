using UnityEngine;
using UnityEngine.InputSystem;
public class cannonshot : MonoBehaviour
{
    [SerializeField] GameObject cannonballprefab;
     [SerializeField] Transform shotpoint;
[SerializeField] float speedshot=15f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
           GameObject cannonball= Instantiate(cannonballprefab,shotpoint.position,shotpoint.rotation);
           cannonball.GetComponent<Rigidbody2D>().linearVelocity=shotpoint.right * speedshot; 
        }
        }
}

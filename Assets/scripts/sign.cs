using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;


public class sign : MonoBehaviour
{
    [SerializeField] private GamemanagerSO gamemanagerSO;
    private bool action1=false;
    private bool action2=false;
    [SerializeField] GameObject blackscremm;
    [SerializeField] GameObject text1;


    
void OnEnable()
    {
       gamemanagerSO.Onmissionstart+=Mission; 
    }
    private void Mission()
    {
        if(action1==true && action2==true)
        {
            blackscremm.SetActive(true);
            text1.SetActive(true);
        }
         if(action1==false && action2==false)
        {
            blackscremm.SetActive(false);
            text1.SetActive(false);
        }
    }
    void OnDisable()
    {
       gamemanagerSO.Onmissionstart-=Mission; 
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(action1==false && action2==false)
        {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            action1=true;
            action2=true;
             StartCoroutine(time());
        }
        }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
          if(collider.CompareTag("Player"))
          {
          Debug.Log("Hola");
        if(action1==false && action2==false)
        {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Debug.Log("press");
            action1=true;
            action2=true;
             StartCoroutine(time());
        }
        }
    }
    }

    IEnumerator time()
    {
         yield return new WaitForSeconds(1.0f);
         action2=false;
    }
   void Start() 
   {
        Debug.Log("Hola");
    }

    // Update is called once per frame
    void Update()
    {
        if(action1==true && action2==false)
        {
        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            action1=false;
            action2=false;
         
        }
        }
        if(Keyboard.current.digit9Key.wasPressedThisFrame)
        {
            Debug.Log(action1);
            Debug.Log(action2);
        }
        if(action1==true && action2==true)
        {
            blackscremm.SetActive(true);
            text1.SetActive(true);
        }
         if(action1==false && action2==false)
        {
            blackscremm.SetActive(false);
            text1.SetActive(false);
        }
    }
}

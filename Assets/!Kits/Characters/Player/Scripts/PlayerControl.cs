using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] InputActionReference move;
    [SerializeField] InputActionReference attack;
    [SerializeField] ParticleSystem particleSystem;

    CharacterController characterController;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        move.action.Enable();
        move.action.started += OnMove;
        move.action.performed += OnMove;
        move.action.canceled += OnMove;
        attack.action.Enable();
    }

    private void OnDisable()
    {
        move.action.Disable();
        attack.action.Disable();
    }

    Vector2 rawMove = Vector2.zero;
    private void OnMove(InputAction.CallbackContext obj)
    {
        rawMove = obj.action.ReadValue<Vector2>();
        characterController.SetRawMove(rawMove);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Enemy"))
        {
            particleSystem.Play();
        } 
    }
    void OnCollisionExit2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Enemy"))
       {
           particleSystem.Stop(); 
        } 
    }
    void Start()
    {
    particleSystem.Stop();
    }
}

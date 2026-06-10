using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 3.0f;

    Rigidbody2D rb2D;
    Animator animator;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.linearVelocity = rawMove * movementSpeed;
    }

    Vector2 rawMove = Vector2.zero;
    public void SetRawMove (Vector2 rawMove)
    {
        this.rawMove = rawMove;
        animator.SetFloat("HorizontalVelocity", rawMove.x);
        animator.SetFloat("VerticalVelocity", rawMove.y);
    }
}

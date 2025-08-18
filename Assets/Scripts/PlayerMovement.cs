using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runspeed;
    [SerializeField] float jumpspeed = 5f;
    [SerializeField] float climbspeed = 5f;
    Rigidbody2D myrigidbody;
    Vector2 moveInput;
    Animator myAnimator;
    CapsuleCollider2D mycapsuleCollider;
    float gravityScaleAtStart;
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        mycapsuleCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = myrigidbody.gravityScale;
    }


    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

    }
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runspeed, myrigidbody.linearVelocityY);
        myrigidbody.linearVelocity = playerVelocity;
        bool hasHorizontalInput = Mathf.Abs(myrigidbody.linearVelocityX) > Mathf.Epsilon;
        myAnimator.SetBool("isrunning", hasHorizontalInput);
    }
    void FlipSprite()
    {
        bool hasHorizontalInput = Mathf.Abs(myrigidbody.linearVelocityX) > Mathf.Epsilon;
        if (hasHorizontalInput)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrigidbody.linearVelocityX), 1f);
        }

    }
    void OnJump(InputValue value)
    {
        if (!mycapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if (value.isPressed)
        {
            myrigidbody.linearVelocity += new Vector2(0f, jumpspeed);
        }
    }
    void ClimbLadder()
    {
        if (!mycapsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myrigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isclimbing", false);
            return;
        }
        Vector2 climbVelocity = new Vector2(myrigidbody.linearVelocityX, moveInput.y * climbspeed);
        myrigidbody.linearVelocity = climbVelocity;
        myrigidbody.gravityScale = 0f;
        bool hasVerticalInput = Mathf.Abs(myrigidbody.linearVelocityY) > Mathf.Epsilon;
        myAnimator.SetBool("isclimbing", hasVerticalInput);
        
    }
}

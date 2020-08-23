using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //
    public float speed = 5.0f;
    public float jumpVelocity = 20f;
    public bool canWalk = true;
    //
    private Vector3 playerScale;
    //
    public BoxCollider2D boxCollider2d;
    public Rigidbody2D rigidbody2d;
    public LayerMask groundLayerMask;
    public LayerMask guardLayerMask;
    //
    private Animator anim;


    private void Start()
    {
        playerScale = transform.localScale;
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerJump();
        PlayerWalk();
        PlayerCrouch();
    }

    private void PlayerWalk()
    {
        if (Input.GetKey(KeyCode.A) && canWalk)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            anim.SetBool("playerIsWalk", true);
        }
        else if (Input.GetKey(KeyCode.D) && canWalk)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            anim.SetBool("playerIsWalk", true);
        }
        else
        {
            anim.SetBool("playerIsWalk", false);
        }
    }

    private void PlayerJump()
    {
        if (IsGrounded())
        {
            anim.SetBool("playerIsJump", false);
            if (Input.GetKey(KeyCode.Space) && canWalk)
            {
                rigidbody2d.velocity = Vector2.up * jumpVelocity;
                anim.SetBool("playerIsJump", true);
            }
            
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, new Vector2(boxCollider2d.bounds.size.x - boxCollider2d.bounds.size.x * 0.4f, boxCollider2d.bounds.size.y), 0f, Vector2.down, 0.1f, groundLayerMask);
        return raycastHit2d.collider != null;
    }

    private void PlayerCrouch()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.localScale = new Vector3(playerScale.x, playerScale.y / 4, playerScale.z);
            canWalk = false;
            anim.SetBool("playerIsCrouch", true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            transform.localScale = new Vector3(playerScale.x, playerScale.y, playerScale.z);
            canWalk = true;
            anim.SetBool("playerIsCrouch", false);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //
    public float speed = 5.0f;
    public float jumpVelocity = 20f;
    //
    public BoxCollider2D boxCollider2d;
    public Rigidbody2D rigidbody2d;
    public LayerMask groundLayerMask;

    // Update is called once per frame
    void Update()
    {
        PlayerJump();
        PlayerWalk();
    }

    private void PlayerWalk()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }

    private void PlayerJump()
    {
        if (IsGrounded() && Input.GetKey(KeyCode.Space))
        {
            rigidbody2d.velocity = Vector2.up * jumpVelocity;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, 0.1f, groundLayerMask);
        return raycastHit2d.collider != null;
    }

}

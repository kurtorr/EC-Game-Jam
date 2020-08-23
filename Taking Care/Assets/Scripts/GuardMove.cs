using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMove : MonoBehaviour
{
    //
    public float guardSpeed = 2.0f;
    public float guardDirection = -1;
    //
    public GameObject pointLight;
    public GameObject lightHitbox;
    //
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider2d;
    public LayerMask groundLayerMask;

    // Update is called once per frame
    void Update()
    {
        GuardWalk();
        if ((guardDirection == -1 && WallLeft()) || (guardDirection == 1 && WallRight()))
        {
            GuardTurn();
        }
            

    }

    private void GuardWalk()
    {
        transform.Translate(guardSpeed * guardDirection * Time.deltaTime, 0, 0);
    }

    private void GuardTurn()
    {
        guardDirection *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        pointLight.transform.Translate(Vector2.up * 0.5f);
        pointLight.transform.Rotate(new Vector3(0, 0, 180));
        lightHitbox.transform.Rotate(new Vector3(180, 0, 0));
        lightHitbox.transform.Translate(Vector2.down * 5.5f);
    }

    private bool WallLeft()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(new Vector2(boxCollider2d.bounds.center.x, boxCollider2d.bounds.center.y + 0.2f), boxCollider2d.bounds.size, 0f, Vector2.left, 0.05f, groundLayerMask);
        return raycastHit2d.collider != null;

    }

    private bool WallRight()
    {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(new Vector2(boxCollider2d.bounds.center.x, boxCollider2d.bounds.center.y + 0.2f), boxCollider2d.bounds.size, 0f, Vector2.right, 0.05f, groundLayerMask);
        return raycastHit2d.collider != null;

    }
}

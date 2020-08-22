using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    //
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if((Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.D)))
        {
            anim.SetBool("playerIsWalk", true);
        }
        else
        {
            anim.SetBool("playerIsWalk", false);
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.name == "LightHitbox")
        {
            SceneManager.LoadScene("SampleScene");
        }

        if (col.gameObject.name == "Cat")
        {
            Debug.Log("END OF LEVEL, LEVELS MUST BE CREATED BEFORE I CAN SWAP BETWEEN THEM");
        }
    }
}

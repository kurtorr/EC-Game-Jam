﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name + " : " + gameObject.name + " : " + Time.time);
        if (col.gameObject.name == "LightHitbox" || col.gameObject.name == "ded")
        {
            SceneManager.LoadScene("Tutorial");
        }

        if (col.gameObject.name == "Zoey")
        {
            SceneManager.LoadScene("YourWinner");
        }
    }
}

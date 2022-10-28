using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject,.05f);
        }
    }

    private void Update()
    {
        Destroy(gameObject,3f);
    }
}

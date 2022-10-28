using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShooterSistem : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Arma;
    public GameObject Cannon;

    public float Bullet_Speed;

    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            GameObject NewBullet= Instantiate(Bullet, Cannon.transform.position, Quaternion.identity) as GameObject;
            NewBullet.transform.rotation = transform.localRotation;
            NewBullet.GetComponent<Rigidbody>().AddForce(NewBullet.transform.forward * (Bullet_Speed * 100) * Time.deltaTime, ForceMode.Impulse);
        }
    }
}

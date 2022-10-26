using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovemment : MonoBehaviour
{
    private CharacterController Player_CC;
    private Vector2 Speed = new Vector2(10,20);
    private GameObject Piso;
    private bool IsGrounded;
    private Vector3 Direccion = new Vector3();

    private void Awake()
    {
        Player_CC = GetComponent<CharacterController>();
        Piso = GameObject.FindWithTag("Floor");
    }

    private void Update()
    {
        Direccion.x = Input.GetAxis("Horizontal") * Speed.x;
        Direccion.z = Input.GetAxis("Vertical") * Speed.x;
        
        CheckGrounded();
        
        if (IsGrounded && Input.GetButton("Jump"))
        {
            Direccion.y = Speed.y;
            IsGrounded = false;
        }
        else
            Direccion.y -= .3f;

        if (Direccion.y > 20)
            Direccion.y = 20;
        Player_CC.Move(Direccion * Time.deltaTime);
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        
        Debug.DrawRay(transform.localPosition, Vector3.down * 1.2f, Color.red);

        if (Physics.Raycast(transform.localPosition, Vector3.down, out hit, 1.2f))
        {
            IsGrounded = Piso.CompareTag("Floor") ? true : false;
        }
    }
}

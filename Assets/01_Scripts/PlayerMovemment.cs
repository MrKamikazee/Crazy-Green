using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovemment : MonoBehaviour
{
    private CharacterController Player_CC;
    private Vector2 Speed = new Vector2(10,5);
    private GameObject Piso;
    private bool IsGrounded;
    private Vector3 Direccion = new Vector3();

    private float xRotation = 0;
    private float yRotation = 0;
    private float MouseX;
    private float MouseY;

    private GameObject[] asd;

    [SerializeField]
    private GameObject Cameras_TP;

    private void Awake()
    {
        Player_CC = GetComponent<CharacterController>();
    }

    private void Start()
    {
        Piso = GameObject.FindWithTag("Floor");
        Cameras_TP = GameObject.FindWithTag("Cameras");
        Cameras_TP.SetActive(false);
    }

    private void Update()
    {
        PlayerMove();
        CameraController();
        ChangeCamera();
    }

    private void PlayerMove()
    {
        if (GameManager.GameManager_Script.Pausa)
            return;
        
        Direccion.z = Input.GetAxis("Horizontal") * Speed.x;
        Direccion.x = Input.GetAxis("Vertical") * Speed.x;
        
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        Vector3 forwardRelativeVerticalInput = Direccion.x * forward;
        Vector3 rightRelativeVerticalInput = Direccion.z * right;

        Vector3 cameraRelativeDirection = forwardRelativeVerticalInput + rightRelativeVerticalInput;

        Direccion.x = cameraRelativeDirection.x;
        Direccion.z = cameraRelativeDirection.z;
        
        CheckGrounded();
        
        if (IsGrounded && Input.GetButton("Jump"))
        {
            Direccion.y = Speed.y;
            IsGrounded = false;
        }
        else
            Direccion.y -= 10f * Time.deltaTime;

        if (Direccion.y > 20)
            Direccion.y = 20;

        Player_CC.Move(Direccion * Time.deltaTime);
    }
    
    private void CheckGrounded()
    {
        RaycastHit hit;
        
        Debug.DrawRay(transform.localPosition, Vector3.down * .2f, Color.red);

        if (Physics.Raycast(transform.localPosition, Vector3.down, out hit, 1.2f))
        {
            IsGrounded = Piso.CompareTag("Floor") ? true : false;
        }
    }

    private void CameraController()
    {
        if (GameManager.GameManager_Script.Pausa)
            return;
        
        MouseX = Input.GetAxis("Mouse X") * (GameManager.GameManager_Script.Sensivility * 30) * Time.deltaTime * 100;
        MouseY = Input.GetAxis("Mouse Y") * (GameManager.GameManager_Script.Sensivility * 30) * Time.deltaTime * 100;
        yRotation -= MouseY;
        xRotation += MouseX;
        yRotation = Mathf.Clamp(yRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(yRotation, xRotation, 0);
        transform.Rotate(Vector3.up * MouseX);
    }

    private void ChangeCamera()
    {
        if (GameManager.GameManager_Script.Pausa)
            return;
        
        if (Input.GetKeyUp(KeyCode.C) && Cameras_TP.activeSelf)
            Cameras_TP.SetActive(false);
        else if(Input.GetKeyUp(KeyCode.C) && !Cameras_TP.activeSelf)
            Cameras_TP.SetActive(true);
    }
}

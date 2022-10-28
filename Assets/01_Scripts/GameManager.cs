using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static public GameManager GameManager_Script;
    public float Sensivility;
    public bool Pausa, Menu_Opciones;

    public Slider Sensibilidad_Slider;

    private void Awake()
    {
        GameManager_Script = this;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //Bloquea el cursor dentro de los limites del juego
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !Pausa)
            Pausar();
        
    }

    public void Pausar()
    {
        Cursor.lockState = CursorLockMode.None;
        Pausa = true;
    }

    public void Renaudar()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Pausa = false;
    }

    public void CambiarSensibilidad()
    {
        Sensivility = Sensibilidad_Slider.value;
    }
}

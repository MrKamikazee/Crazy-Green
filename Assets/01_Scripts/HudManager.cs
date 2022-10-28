using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class HUDManager : MonoBehaviour
{
    private bool MenuAbierto;
    
    public GameObject BTN_Continuar;

    public GameObject Panel_Pausa, Panel_Opciones;

    public Slider Sensibilidad_Slider;

    public TextMeshProUGUI Sensibilidad_Text;

    private void Start()
    {
        DOTween.Init();
    }

    private void Update()
    {
        if (GameManager.GameManager_Script.Pausa)
            JuegoPausado();
        else
            JuegoNoPausado();
    }

    private void JuegoPausado()
    {
        if (MenuAbierto)
            return;

        MenuAbierto = true;
        Panel_Pausa.SetActive(true);
    }

    public void JuegoNoPausado()
    {
        if (!MenuAbierto)
            return;

        MenuAbierto = false;
        Panel_Pausa.SetActive(false);
        
        if (!Panel_Opciones.activeSelf)
            return;

        Sensibilidad_Text.text = "Sensibilidad: " + Sensibilidad_Slider.value * 100;
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Salir()
    {
        Application.Quit();
    }
}

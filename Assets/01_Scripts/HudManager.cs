using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Slider Barra_Progreso;
    public TextMeshProUGUI Texto_Progreso;

    public Image[] WASD = new Image[4];
    public Image[] Flechas = new Image[4];

    public void Start()
    {
        DOTween.Init();
    }

    public void Salir()
    {
        Application.Quit();
    }

    public void StartLoadGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(2);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            Barra_Progreso.value = progress;
            Texto_Progreso.text = "Cargando " + (progress * 100f) + "%";
        }
        yield return new WaitForSeconds(2f);
    }

    public void StartTutorial()
    {
        Sequence Tutorial = DOTween.Sequence();
        Color Color_Tutorial = new Color(200, 200, 200);
        Tutorial.Append(WASD[0].DOColor(Color_Tutorial, 2f)).Join(Flechas[0].DOColor(Color_Tutorial, 2f));
    }
}

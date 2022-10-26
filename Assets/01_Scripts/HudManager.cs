using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HudManager : MonoBehaviour
{
    public Slider Barra_Progreso;
    public TextMeshProUGUI Texto_Progreso;

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
}

using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Slider Barra_Progreso;
    public TextMeshProUGUI Texto_Progreso;

    public GameObject[] WASD = new GameObject[4];
    public GameObject[] Flechas = new GameObject[4];
    public GameObject LetraC;
    
    public GameObject LoadGame_Panel;

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
        if (!LoadGame_Panel.activeSelf)
            LoadGame_Panel.SetActive(true);
        StartCoroutine(LoadGame());
        DOTween.Clear();
    }

    IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(2f);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(1);
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f);
            Barra_Progreso.value = progress;
            Texto_Progreso.text = "Cargando " + (progress * 100f) + "%";
            yield return null;
        }

        yield return new WaitForSeconds(2f);
    }

    public void StartTutorial()
    { 
        Sequence Tutorial = DOTween.Sequence();
        Tutorial.AppendInterval(.8f)
            .Append(WASD[0].GetComponent<Image>().DOColor(Color.gray, 1f))
            .Join(Flechas[0].GetComponent<Image>().DOColor(Color.gray, 1f))
 
            .AppendInterval(.6f)
            .Append(WASD[0].GetComponent<Image>().DOColor(Color.white, 1f))
            .Join(Flechas[0].GetComponent<Image>().DOColor(Color.white, 1f))
 
            .AppendInterval(1.6f)
            .Append(WASD[2].GetComponent<Image>().DOColor(Color.gray, 1f))
            .Join(Flechas[2].GetComponent<Image>().DOColor(Color.gray, 1f))
 
            .AppendInterval(.6f)
            .Append(WASD[2].GetComponent<Image>().DOColor(Color.white, 1f))
            .Join(Flechas[2].GetComponent<Image>().DOColor(Color.white, 1f))
 
            .AppendInterval(1.8f)
            .Append(WASD[3].GetComponent<Image>().DOColor(Color.gray, 1f))
            .Join(Flechas[3].GetComponent<Image>().DOColor(Color.gray, 1f))
 
            .AppendInterval(.6f)
            .Append(WASD[3].GetComponent<Image>().DOColor(Color.white, 1f))
            .Join(Flechas[3].GetComponent<Image>().DOColor(Color.white, 1f))
 
            .AppendInterval(1.8f)
            .Append(WASD[1].GetComponent<Image>().DOColor(Color.gray, 1f))
            .Join(Flechas[1].GetComponent<Image>().DOColor(Color.gray, 1f))
 
            .AppendInterval(.6f)
            .Append(WASD[1].GetComponent<Image>().DOColor(Color.white, 1f))
            .Join(Flechas[1].GetComponent<Image>().DOColor(Color.white, 1f))
 
            .AppendInterval(.5f)
            .Append(WASD[0].GetComponent<Image>().DOFade(0, .5f))
            .Join(WASD[1].GetComponent<Image>().DOFade(0, .5f))
            .Join(WASD[2].GetComponent<Image>().DOFade(0, .5f))
            .Join(WASD[3].GetComponent<Image>().DOFade(0, .5f))
            .Join(Flechas[0].GetComponent<Image>().DOFade(0, .5f))
            .Join(Flechas[1].GetComponent<Image>().DOFade(0, .5f))
            .Join(Flechas[2].GetComponent<Image>().DOFade(0, .5f))
            .Join(Flechas[3].GetComponent<Image>().DOFade(0, .5f))
            .Append(LetraC.GetComponent<Image>().DOFade(255, .5f))
 
            .AppendInterval(.4f)
            .Append(LetraC.GetComponent<Image>().DOColor(Color.gray, 1f))
 
            .AppendInterval(.3f)
            .Append(LetraC.GetComponent<Image>().DOColor(Color.white, 1f))
             
            .AppendInterval(.8f)
            .Append(LetraC.GetComponent<Image>().DOColor(Color.gray, 1f))
 
            .AppendInterval(.5f)
            .Append(LetraC.GetComponent<Image>().DOColor(Color.white, 1f))
            
            .AppendInterval(1f)
            .OnComplete(StartLoadGame);
    }
}

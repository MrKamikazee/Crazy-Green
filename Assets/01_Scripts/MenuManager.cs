using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class MenuManager : MonoBehaviour
{
    public Slider Barra_Progreso;
    public TextMeshProUGUI Texto_Progreso;

    public GameObject[] WASD = new GameObject[4];
    public GameObject[] Flechas = new GameObject[4];
    public GameObject LetraC;
    public GameObject LetraEsc;
    public GameObject[] Mouse_Idle = new GameObject[2];
    public GameObject[] Mouse_Moving = new GameObject[2];

    public GameObject Video1, Video2;
    
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
            .Append(LetraC.GetComponent<Image>().DOFade(1, .5f))
 
            .AppendInterval(.4f)
            .Append(LetraC.GetComponent<Image>().DOColor(Color.gray, 1f))
 
            .AppendInterval(.3f)
            .Append(LetraC.GetComponent<Image>().DOColor(Color.white, 1f))
             
            .AppendInterval(.8f)
            .Append(LetraC.GetComponent<Image>().DOColor(Color.gray, 1f))
 
            .AppendInterval(.5f)
            .Append(LetraC.GetComponent<Image>().DOColor(Color.white, 1f))
            
            .AppendInterval(1f)
            .OnComplete(Tutorial2);
    }

    private void Tutorial2()
    {
        Sequence Tutorial2 = DOTween.Sequence();
        Tutorial2.Append(Video1.GetComponent<RawImage>().DOFade(0, 1f))
            .Join(LetraC.GetComponent<Image>().DOFade(0, 1f))
            .AppendCallback(Video2.GetComponent<VideoPlayer>().Play)
            .Append(Video2.GetComponent<RawImage>().DOFade(1, 1f))
            .Join(LetraEsc.GetComponent<Image>().DOFade(1, 1f))
            .Join(Mouse_Idle[0].GetComponent<Image>().DOFade(1, 1f))
            .Join(Mouse_Moving[0].GetComponent<Image>().DOFade(1, 1f))

            .Append(LetraEsc.GetComponent<Image>().DOColor(Color.gray, .5f))
            .Append(LetraEsc.GetComponent<Image>().DOColor(Color.white, .5f))

            .AppendInterval(3.5f)
            .AppendCallback(() => MouseClick("On"))
            .AppendInterval(.5f)
            .AppendCallback(() => MouseClick("Off"))

            .AppendInterval(2f)
            .AppendCallback(() => MouseClick("On"))
            .AppendInterval(.8f)
            .AppendCallback(() => MouseClick("Off"))
            .AppendInterval(1.4f)
            .AppendCallback(() => MouseClick("On"))
            .AppendInterval(1f)
            .AppendCallback(() => MouseClick("Off"))

            .AppendInterval(1.5f)
            .AppendCallback(() => MouseMove("On"))
            .AppendInterval(5.5f)
            .AppendCallback(() => MouseMove("Off"))
            
            .AppendInterval(1f)
            .Append(Video2.GetComponent<RawImage>().DOFade(0, 1f))
            .Join(LetraEsc.GetComponent<Image>().DOFade(0, 1f))
            .Join(Mouse_Idle[0].GetComponent<Image>().DOFade(0, 1f))
            .Join(Mouse_Moving[0].GetComponent<Image>().DOFade(0, 1f))
            .OnComplete(StartLoadGame);
    }

    private void MouseClick(string S)
    {
        if (S == "On")
            Mouse_Idle[1].SetActive(true);
        else if (S == "Off")
            Mouse_Idle[1].SetActive(false);
    }

    private void MouseMove(string S)
    {
        if (S == "On")
            Mouse_Moving[1].SetActive(true);
        else if (S == "Off")
            Mouse_Moving[1].SetActive(false);
    }
}
